using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RobotFreeAnim : MonoBehaviour {

	
	Animator anim;
	[SerializeField] Transform player;
    [SerializeField] NavMeshAgent robot;

    // Use this for initialization
    void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
      //  gameObject.transform.eulerAngles = player.position;

    }

	// Update is called once per frame
	void Update()
	{

		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("anim_open"))
		{
			CheckKey();
			//	gameObject.transform.eulerAngles = player.position;

			gameObject.transform.LookAt(player.position);

			robot.SetDestination(player.position);
		}
    }

	void CheckKey()
	{
		// Walk
	
		if (Keyboard.current.wKey.IsPressed() ||
			Keyboard.current.aKey.IsPressed() ||
			Keyboard.current.dKey.IsPressed() ||
            Keyboard.current.sKey.IsPressed())


        {
            anim.SetBool("Walk_Anim", true);
		}
		else 
		{
			anim.SetBool("Walk_Anim", false);
		}

		

		// Roll
		if (Keyboard.current.shiftKey.IsPressed())
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
			
		if (Keyboard.current.ctrlKey.IsPressed())
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
	}

}
