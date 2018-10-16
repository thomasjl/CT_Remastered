using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

    public Text MyLevel;
    public Text MyTime;
    public Text BestTime;

    public UIManager uiManager;

    public float secondsCount;

    void Update()
    {
        if(uiManager.state == State.GAME)
        {
            UpdateTimerUI();
        }
        else
        {
            TimerUIZero();
        }

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            uiManager.SetState("WIN");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            uiManager.SetState("LOSE");
        }
    }
        //call this on update
        public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        MyTime.text = "Time : " + (int)secondsCount ;
       
    }

    public void TimerUIZero()
    {
        secondsCount = 0f;

    }
}
