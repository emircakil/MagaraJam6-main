﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;
	public float startTime = 10000;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;

        if (rotSpeed > 0 && !anim.GetBool("Open_Anim")) 
        {
            anim.SetBool("Walk_Anim", true);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }
        startTime -= Time.deltaTime;
       

		if (startTime < 0) {
			anim.SetBool("Open_Anim", false);
		}
    }

    void CheckKey()
	{
		// Walk
		
		
/*
		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
*/
	}

}
