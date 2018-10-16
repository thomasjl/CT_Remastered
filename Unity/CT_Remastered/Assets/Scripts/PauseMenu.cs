using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool GameIsPaused;
    public UIManager uiManager;


    void Update () {
        //When Escapte button is pressed we open/close the Contextual Menu
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        //Back in Game and game is not paused anymore
        uiManager.SetState("GAME");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //Contextual Menu is open and game is paused
        uiManager.SetState("CONTEXTUALMENU");
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
