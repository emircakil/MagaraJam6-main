using CharacterandLowEnemy.Characterr.CharacterScripts;
using CharacterandLowEnemy.Characterr.CharacterScripts.GunScripts;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace character.CameraScript.LowEnemy.EnemyScripts
{
    public class BossEnemy : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private GameObject character;
        [SerializeField] private float designatedDistance = 10f;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 distance;
        [SerializeField] private int maxHealth = 100;
        private float currentHealth;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _prefab;
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            character = GameObject.FindGameObjectWithTag("Player");
            currentHealth = maxHealth;
            
        }

        private void Update()
        {
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
            distance = transform.position - character.transform.position;

            Following();
            SetAnimationsValue();
            Debug.Log(currentHealth);
        }

        private void SetAnimationsValue()
        {
            _animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
            _animator.SetFloat("Attack", distance.magnitude);
        }
     
     



        private void Following()
        {
            if (!(distance.magnitude <= designatedDistance)) return;

            var targetPosition = character.transform.position;
            transform.LookAt(character.transform);
            _agent.SetDestination(targetPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hasaer Verildii");
            if (other.gameObject.CompareTag("Bullet"))
            {
               TakeDamage(BulletScript.instance.bulletDamage);


            }
        }
        private void TakeDamage(float damage)
        {
            currentHealth -= damage;
        }
        private void Die()
        {

            _animator.SetTrigger("dead");
            if(_prefab != null)
            {
                Instantiate(_prefab,transform.position,transform.rotation);
            }
            Destroy(gameObject,5f);
        }
        //Animation Event
        public void Punch()
        {
            CharacterHealt._instance.SetHealt(40);
        }
        public void audioController()
        {
            _audioSource.Play();
        }
    }
}