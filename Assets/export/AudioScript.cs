using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    public List<AudioClip> soundList;
    private AudioSource audioSource;
    private int currentScene;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            // Eğer bu nesne daha önce oluşturulmadıysa, işlemi gerçekleştir.
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            // Eğer bu nesne zaten oluşturulduysa, tekrar oluşturulmasını engelle ve bu nesneyi yok et.
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(currentScene==SceneManager.sceneCount)
            PlayAndRemoveFirstSound();
    }

    void PlayAndRemoveFirstSound()
    {
        if (soundList.Count > 0)
        {
            // İlk elemanı al ve çal
            audioSource.clip = soundList[0];
            audioSource.Play();

            // İlk elemanı listeden sil
            soundList.RemoveAt(0);
            currentScene++;
        }
        else
        {
            Debug.LogError("Ses listesi boş!");
        }
    }

}