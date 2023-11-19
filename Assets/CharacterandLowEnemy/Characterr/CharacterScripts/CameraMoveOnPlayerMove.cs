using DG.Tweening;
using UnityEngine;

namespace CharacterandLowEnemy.Characterr.CharacterScripts
{
    public class CameraMoveOnPlayerMove : MonoBehaviour
    {
        public Transform mainCameraTransform;
        [SerializeField] private Transform player;
        public float moveDistance = 0.2f; // Hareket mesafesi
        public float moveDuration = 1f; // Hareket süresi

        private Vector3 originalPosition;
        private Vector3 targetPosition;
        private Vector3 previousPosition;

        void Start()
        {
            if (mainCameraTransform == null)
            {
                mainCameraTransform = Camera.main.transform;
            }

            originalPosition = mainCameraTransform.localPosition;
            previousPosition = player.position;
            targetPosition = originalPosition;
        }

        void Update()
        {
            // Karakterin mevcut pozisyonunu al
            var currentPosition = player.position;

            // Karakterin pozisyonunda bir değişiklik var mı kontrol et
            if (currentPosition != previousPosition)
            {
                // Eğer karakter hareket ediyorsa, kamera hedef pozisyonunu güncelle
                targetPosition = new Vector3(originalPosition.x + Mathf.Sign(currentPosition.x - previousPosition.x) * moveDistance, originalPosition.y, originalPosition.z);

                // Eğer bir animasyon devam ediyorsa, onu iptal et
                mainCameraTransform.DOComplete();

                // Kamera animasyonlu bir şekilde hedef pozisyonuna git
                mainCameraTransform.DOLocalMove(targetPosition, moveDuration).SetEase(Ease.OutQuad);
            }
            else
            {
                // Eğer karakter hareket etmiyorsa, kamera belirli pozisyonlar arasında gidip gel
                // Eğer bir animasyon devam ediyorsa, onu iptal et
                mainCameraTransform.DOComplete();

                mainCameraTransform.DOLocalMoveX(originalPosition.x + moveDistance, moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
                {
                    // Hareket tamamlandığında, hedef pozisyonu tersine çevir
                    mainCameraTransform.DOLocalMoveX(originalPosition.x - moveDistance, moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
                    {
                        // Döngüyü devam ettir
                        mainCameraTransform.DOLocalMoveX(originalPosition.x + moveDistance, moveDuration).SetEase(Ease.OutQuad);
                    });
                });
            }

            // Önceki pozisyonu güncelle
            previousPosition = currentPosition;
        }
    }
}
