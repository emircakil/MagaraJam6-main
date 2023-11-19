using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public collectiable coll;
    bool itHasKey;
    private void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && itHasKey){
        
            uiObject.SetActive(true);


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && itHasKey) {

        }
    }

    private void Update()
    {
        itHasKey = coll.IsGot;

        if (itHasKey)
        {
            if (Keyboard.current.eKey.IsPressed())
            {

                SceneManager.LoadScene("mainScene");
            }
        }

    }

}
