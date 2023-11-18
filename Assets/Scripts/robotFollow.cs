using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotFollow : MonoBehaviour
{

    [SerializeField] NavMeshAgent robot;
    [SerializeField] Transform player;
    [SerializeField] Animator anim;
    Rigidbody rb;
    float speed;
    float timer = 10f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
     
        
    }
   

    void Update()
    {
        speed = Vector3.Magnitude(rb.velocity);
        robot.SetDestination(player.position);
            

        if (timer > 0)
        {

            timer -= Time.deltaTime;

        }

        if (timer <= 0)
        {

            anim.SetBool("OpenAnim", false);
        }

        if (speed > 0 && !anim.GetBool("OpenAnim"))
        {
            anim.SetBool("WalkAnim", true);
        }
        else {

            anim.SetBool("WalkAnim", false);
        }

    }
}
