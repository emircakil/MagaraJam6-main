using DG.Tweening;
using UnityEngine;

namespace CharacterandLowEnemy.Characterr.CharacterScripts.GunScripts
{
    public class GunScript : MonoBehaviour
    {
        public static GunScript İnstance;
  
        [SerializeField]private GameObject bulletPrefab; // Mermi modeli
        [SerializeField]private Transform gunTransform; // Silahın transformu
        [SerializeField]private Transform muzzle;
        [SerializeField] private Camera _camera;
        [SerializeField]private float recoilAmount = 0.1f; // Sekme miktarı

        private Vector3 _startPos;

        private void Awake()
        {
            İnstance = this;
            _startPos = gunTransform.localRotation.eulerAngles;
        }


        public void Fire()
        {
            var ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Kameranın ortasına doğru bir ışın fırlatılıyor
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit)) return;
            var hitPoint = hit.point;

            var bullet = Instantiate(bulletPrefab, muzzle.position, gunTransform.rotation);

            bullet.transform.LookAt(hitPoint); 
            
            ApplyRecoil();
        }

        void ApplyRecoil()
        {
            // Silahın sekmesini simüle etmek için kamerayı veya karakteri biraz sallayabilirsin
            var recoil = new Vector3(Random.Range(-recoilAmount, recoilAmount), Random.Range(-recoilAmount, recoilAmount), Random.Range(-recoilAmount, recoilAmount));
            transform.Rotate(recoil);
            transform.DOLocalRotate(_startPos, .2f);
        }
    }
}
