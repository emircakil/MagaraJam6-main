using System;
using UnityEngine;

namespace CharacterandLowEnemy.Characterr.CharacterScripts.GunScripts
{
    public class BulletScript : MonoBehaviour
    {
        public static BulletScript instance;
        [SerializeField] private float speed = 10f; // Mermi hızı
        [SerializeField] private float lifeTime = 5f; // Mermi maksimum menzil
        public float bulletDamage = 2f;// Mermi hasarı

        private void Awake()
        {
            instance = this;
        }

        void Update()
        {
            // Mermiyi ileri doğru hareket ettir
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));

            // Mermi belirli bir süreden sonra yok olur
            Destroy(gameObject, lifeTime);
        }
    }
}