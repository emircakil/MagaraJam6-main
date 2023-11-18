using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiable : MonoBehaviour
{

    public bool IsGot = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
        
            Destroy(gameObject);
            IsGot = true;
        }
    }
}
