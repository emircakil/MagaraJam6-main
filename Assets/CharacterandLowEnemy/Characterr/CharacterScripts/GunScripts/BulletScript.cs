using UnityEngine;

namespace CharacterandLowEnemy.Characterr.CharacterScripts.GunScripts
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private float speed = 10f; // Mermi hızı
        [SerializeField] private float lifeTime = 5f; // Mermi maksimum menzil
        [SerializeField] private float bulletDamage = 2f;// Mermi hasarı

        void Update()
        {
            // Mermiyi ileri doğru hareket ettir
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));

            // Mermi belirli bir süreden sonra yok olur
            Destroy(gameObject, lifeTime);
        }
    }
}