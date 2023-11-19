using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneCollision : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
            { 
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName);

            }
    }
}
