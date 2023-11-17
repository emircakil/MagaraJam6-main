using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotFollow : MonoBehaviour
{

    [SerializeField] NavMeshAgent robot;
    [SerializeField] Transform player;
    [SerializeField] Animator anim;
    void Start()
    {
        
    }

    void Update()
    {
        if (anim.GetBool("Open_Anim") == false)
        {
            robot.SetDestination(player.position);
        }
    }
}
