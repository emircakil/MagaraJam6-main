using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterandLowEnemy.Characterr.CharacterScripts
{
    public class CharacterHealt : MonoBehaviour
    {
        public static CharacterHealt _instance;

        [SerializeField] private Q_Vignette_Split _qVignetteSplit;
        private int healt = 100;
        [SerializeField] private float duration = 2f;
        private float minValue = 0f, maxValue = 2f;

        private void Awake()
        {
            _instance = this;
            PlayerPrefs.DeleteKey("Healt");
            if (!PlayerPrefs.HasKey("Healt"))
                PlayerPrefs.SetInt("Healt", healt);
            else
                healt = PlayerPrefs.GetInt("Healt");
        
            StartCoroutine(IncreaseHealthOverTime(10f, 5));

        }

        private void Update()
        {
            if (PlayerPrefs.GetInt("Healt")<=0)
            {
                SceneManager.LoadScene(1);
            }
        }

        private IEnumerator IncreaseHealthOverTime(float interval, int amount)
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
        
                // Canı arttır ve PlayerPrefs'e kaydet
                healt += amount;
                if (healt > 100)
                    healt = 100;
        
                PlayerPrefs.SetInt("Healt", healt);
        
                // Eğer can 100'e ulaştıysa artışı durdur
                if (healt >= 100)
                    break;
            }
        }


        public void SetHealt(int damage)
        {
            healt -= damage;
            PlayerPrefs.SetInt("Healt", healt);
            
            if (PlayerPrefs.GetInt("Healt") <= 30)
            {
                _qVignetteSplit.mainScale = 1f;
                _qVignetteSplit.skyScale = 1f;
            }

            DOTween.To(() => _qVignetteSplit.mainScale, x =>
                {
                    _qVignetteSplit.mainScale = x;
                    _qVignetteSplit.skyScale = x;
                }, maxValue, duration)
                .OnComplete(() =>
                {
                    if (PlayerPrefs.GetInt("Healt") > 30)
                        ResetVinyet();
                });
        }

        private void ResetVinyet()
        {
            DOTween.To(() => _qVignetteSplit.mainScale, x =>
            {
                _qVignetteSplit.mainScale = x;
                _qVignetteSplit.skyScale = x;
            }, minValue, duration);
        }
    }
}