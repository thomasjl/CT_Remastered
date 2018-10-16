using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private bool hasWon;

    void Start()
    {
        hasWon = false;
    }

    void Update()
    {
        if(hasWon)
        {
            hasWon = false;
            InGameUIManager.instance.playerWin();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Win");
            hasWon = true;
        }

    }


}