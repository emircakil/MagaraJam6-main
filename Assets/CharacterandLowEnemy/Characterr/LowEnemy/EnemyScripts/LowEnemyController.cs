using CharacterandLowEnemy.Characterr.CharacterScripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace CharacterandLowEnemy.Characterr.LowEnemy.EnemyScripts
{
    public class LowEnemyController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private GameObject character;
        [SerializeField] private float designatedDistance = 10f;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _blood;
        private Vector3 distance;


        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            character = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            distance = transform.position - character.transform.position;
            
            Following();
            SetAnimationsValue();
        }

        private void SetAnimationsValue()
        {
            _animator.SetFloat("Speed",_rigidbody.velocity.magnitude);
            _animator.SetFloat("Punch",distance.magnitude);    
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
            if (other.gameObject.CompareTag("Bullet"))
            {
                Instantiate(_blood,transform.position+Vector3.up*1.5f,quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        //Animation Event
        public void Punch(GameObject other)
        {
            CharacterHealt._instance.SetHealt(10);
        }
    }
}