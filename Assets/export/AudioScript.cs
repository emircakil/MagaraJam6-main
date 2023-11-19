using UnityEngine;
using System.Collections.Generic;

public class AudioScript : MonoBehaviour
{
    public List<AudioClip> soundList;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        }
        else
        {
            Debug.LogError("Ses listesi boş!");
        }
    }

}