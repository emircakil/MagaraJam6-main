using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void nextScene() { 
    
        SceneManager.LoadScene(sceneName);
    }

   
}
