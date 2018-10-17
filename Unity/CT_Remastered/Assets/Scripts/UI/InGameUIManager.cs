using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum UIState
{
    WIN,
    CONTEXTUAL,
    DIE,
    RULES,
    GAME,

    COUNT
}

public class InGameUIManager : MonoBehaviour {

    public GameObject winUI;
    public GameObject contextualUI;
    public GameObject diedUI;
    public GameObject rulesUI;
    public GameObject highScoreUI;

    public Text textLevel;

    public Text highScoreLevel;

    public Text currentScoreLevel;


    public static InGameUIManager instance;

    public UIState state;

    public bool GameIsPaused;

    private GameObject player;

    private float timer;



    // Use this for initialization
    void Start() {
      

        state = UIState.GAME;

        instance = this;
        winUI.SetActive(false);
        contextualUI.SetActive(false);
        diedUI.SetActive(false);
        rulesUI.SetActive(false);
        highScoreUI.SetActive(false);

        GameIsPaused = false;

        player = GameObject.FindGameObjectWithTag("Player");

        Time.timeScale = 1f;
        timer = Time.time;

    }

    // Update is called once per frame
    void Update() {
        
        //print UI
        winUI.SetActive(state == UIState.WIN);
        contextualUI.SetActive(state == UIState.CONTEXTUAL);
        diedUI.SetActive(state == UIState.DIE);
        rulesUI.SetActive(state == UIState.RULES);

        //When Escapte button is pressed we open/close the Contextual Menu
        if (Input.GetKeyDown(KeyCode.Escape) && state != UIState.WIN)
        {
            continueGame();
        }

        if(state == UIState.DIE && Input.anyKeyDown)
        {
            retryLevel();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerWin();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void continueGame()
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


    public void SetState(UIState newState)
    {
        if (newState != UIState.WIN)
        {
            highScoreUI.SetActive(false);
        }

        state = newState;        

        //desactive l'orientation du fps quand un ui est affiche
        if(newState != UIState.GAME)
        {
            Time.timeScale = 0f;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
      
    }

    public void SetState(string newState)
    {
        for (UIState stateEnum = 0; stateEnum < UIState.COUNT; stateEnum++)
        {
            if (newState == stateEnum.ToString())
            {
                SetState(stateEnum);
                return;
            }

        }

        Debug.LogError("Invalid state request: " + newState);
    }
        


    public void playerDie()
    {

        SetState(UIState.DIE);
    }

    public void playerWin()
    {
        float timeToFinish = Mathf.Round((Time.time - timer)*10f)/10f;
        Debug.Log("timeToFinish "+ timeToFinish);

       
        currentScoreLevel.text = "SCORE "+timeToFinish.ToString();
       

        Time.timeScale = 0f;

        if ( (PlayerPrefs.GetFloat("HighScoreLevel" + PlayerPrefs.GetInt("CurrentLevel"))==0f) ||( timeToFinish < PlayerPrefs.GetFloat("HighScoreLevel" + PlayerPrefs.GetInt("CurrentLevel"))))
        {      
            highScoreUI.SetActive(true);
            PlayerPrefs.SetFloat("HighScoreLevel" + PlayerPrefs.GetInt("CurrentLevel"), timeToFinish);
        }

        if (PlayerPrefs.GetFloat("HighScoreLevel" + PlayerPrefs.GetInt("CurrentLevel")) != 0f)
        {
            highScoreLevel.text = "High Score " + PlayerPrefs.GetFloat("HighScoreLevel" + PlayerPrefs.GetInt("CurrentLevel")).ToString();
        }
        else
        {
            highScoreLevel.text = "";
        }


        SetState(UIState.WIN);
    }

    public void showRules()
    {
        SetState(UIState.RULES);
    }

    public void showContextual()
    {
        textLevel.text = "Level " + PlayerPrefs.GetInt("CurrentLevel");
        SetState(UIState.CONTEXTUAL);

    }

   
    void Resume()
    {
        //Back in Game and game is not paused anymore
        SetState(UIState.GAME);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //Contextual Menu is open and game is paused
        textLevel.text = "Level " + PlayerPrefs.GetInt("CurrentLevel");
        SetState(UIState.CONTEXTUAL);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Homepage");
    }

    public void goNext()
    {
        Debug.Log("current "+ PlayerPrefs.GetInt("CurrentLevel"));
        int nextLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
        PlayerPrefs.SetInt("CurrentLevel", nextLevel);

        SceneManager.LoadScene("Level"+ nextLevel);
    }

    public void retryLevel()
    {
        Debug.Log("current Level " + PlayerPrefs.GetInt("CurrentLevel"));
        SceneManager.LoadScene("Level"+PlayerPrefs.GetInt("CurrentLevel"));
    }


}
