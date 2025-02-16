﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTruck : MonoBehaviour {

    private RaycastHit hit;
    private NavMeshAgent agent;

    public GameObject target;

    private bool MoveAcrossNavMeshesStarted;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;

        //variation de la vitesse de chaque truck (-10% à +10%, autrement, même comportement)
        float nbr = Random.Range(-(40 * agent.speed) / 100, (30 * agent.speed) / 100);
        agent.speed = agent.speed + nbr;

        MoveAcrossNavMeshesStarted = false;



    }


    void Update () {

        //set good rotation
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation ;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 0.6f);

        }
        

        if (target.GetComponent<Target>().canGo)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if(distance<5.0f)
            {
                Destroy(gameObject);
                
            }
            
            agent.SetDestination(target.transform.position);
        }

       
    }   


}
