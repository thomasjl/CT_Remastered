using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private GameObject truck;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!controller.isGrounded)
        {
            transform.parent = null;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {        
        if (hit.collider.tag == "Truck")
        {
            truck = hit.collider.gameObject;
            transform.parent = truck.transform;
        }
    }
}
