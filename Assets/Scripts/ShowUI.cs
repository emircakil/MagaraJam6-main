using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Update()
    {
        itHasKey = coll.IsGot;

        if (itHasKey)
        {
            if (Keyboard.current.eKey.IsPressed())
            {

                Destroy(uiObject);
            }
        }

        Debug.Log(itHasKey);
        
        

    }

}
