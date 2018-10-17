using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private GameObject truck;
    private CharacterController controller;

    private bool hasDied;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        hasDied = false;
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
        Debug.Log("HIIIT");
        if (hit.collider.tag == "Truck")
        {
            truck = hit.collider.gameObject;
            transform.parent = truck.transform;
        }
        else if(!hasDied)
        {
            //player a touche autre chose qu'un camion, il a perdu
            hasDied = true;
            InGameUIManager.instance.playerDie();

        }
    }
    

    
}
