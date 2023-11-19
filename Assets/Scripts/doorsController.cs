using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsController : MonoBehaviour
{

    [SerializeField] GameObject sehvet1;
    [SerializeField] GameObject kibir2;
    [SerializeField] GameObject acgozluluk3;
    [SerializeField] GameObject oburluk4;
    [SerializeField] GameObject haset5;
    [SerializeField] GameObject tembellik6;
    [SerializeField] GameObject ofke7;
    int no = 0;


    void Start()
    {/*
        sehvet1 = GetComponent<GameObject>();
        kibir2 = GetComponent<GameObject>();
        acgozluluk3 = GetComponent<GameObject>();
        oburluk4 = GetComponent<GameObject>();
        haset5 = GetComponent<GameObject>();
        tembellik6 = GetComponent<GameObject>();
        ofke7 = GetComponent<GameObject>();
        */
        sehvet1.SetActive(true);
        kibir2 .SetActive(false);
        acgozluluk3.SetActive(false);
        oburluk4.SetActive(false);
        haset5.SetActive(false);
        tembellik6.SetActive(false);
        ofke7 .SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sehvet1.activeSelf && no == 0) {

            kibir2.SetActive(true);
            no++;
        }

        if(kibir2.activeSelf && no == 1)
        {
            acgozluluk3.SetActive(true);
            no++;
        }

        if (acgozluluk3.activeSelf && no == 2) { 
        
            oburluk4.SetActive(true);
            no++;
        }

        if (oburluk4.activeSelf && no == 3)
        {
            haset5.SetActive(true);
            no++;
        }

        if (haset5.activeSelf && no == 4)
        {
            tembellik6.SetActive(true);
            no++;
        }

        if (tembellik6.activeSelf && no == 5) { 
        
            ofke7.SetActive(true);
            no++;
        }

        if (no == 6) { 
        
            
        }
    }
}
