using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    MENU,
    LEVELSELECTION,
    WIN,
    LOSE,
    CONTEXTUALMENU,
    OPTIONS,
    TUTORIAL,
    CREDIT,
    GAME,

    COUNT
}

public class UIManager : MonoBehaviour
{
    public State state;

    public GameObject guiMenu;
    public GameObject guiLevelSelection;
    public GameObject guiWin;
    public GameObject guiLose;
    public GameObject guiContextualMenu;
    public GameObject guiOptions;
    public GameObject guiTutorial;
    public GameObject guiCredit;
    public GameObject guiGame;
    static public UIManager instance;



    void Awake()
    {
        if (instance != null) Debug.LogError("Double singleton!");
        instance = this;

        guiMenu.SetActive(false);
        guiLevelSelection.SetActive(false);
        guiWin.SetActive(false);
        guiLose.SetActive(false);
        guiContextualMenu.SetActive(false);
        guiOptions.SetActive(false);
        guiTutorial.SetActive(false);
        guiCredit.SetActive(false);
        guiGame.SetActive(false);
}

    void Start()
    {
        //State Menu is the menu we start the game with
        state = State.MENU;

        //Initialisation of the position of all the gui at the reset position, where the LevelSelection GUI is
        guiMenu.transform.position = guiLevelSelection.transform.position;
        guiWin.transform.position = guiLevelSelection.transform.position;
        guiLose.transform.position = guiLevelSelection.transform.position;
        guiContextualMenu.transform.position = guiLevelSelection.transform.position;
        guiOptions.transform.position = guiLevelSelection.transform.position;
        guiTutorial.transform.position = guiLevelSelection.transform.position;
        guiCredit.transform.position = guiLevelSelection.transform.position;
        guiGame.transform.position = guiLevelSelection.transform.position;       

    }

  

    void Update()
    {
        //Association of the state with the right GameObject
        //The GameObject is active when its associated state is selected
        guiMenu.SetActive(state == State.MENU);
        guiLevelSelection.SetActive(state == State.LEVELSELECTION);
        guiWin.SetActive(state == State.WIN);
        guiLose.SetActive(state == State.LOSE);
        guiContextualMenu.SetActive(state == State.CONTEXTUALMENU);
        guiOptions.SetActive(state == State.OPTIONS);
        guiTutorial.SetActive(state == State.TUTORIAL);
        guiCredit.SetActive(state == State.CREDIT);
        guiGame.SetActive(state == State.GAME);
    }

    public void SetState(State newState)
    {
        state = newState;
    }

    //Set State according to its name
    public void SetState(string newState)
    {
        for (State stateEnum = 0; stateEnum < State.COUNT; stateEnum++)
        {
            if (newState == stateEnum.ToString())
            {
                SetState(stateEnum);
                return;
            }

        }

        Debug.LogError("Invalid state request: " + newState);
    }

    //Quit game
    public void OnClickQuit()
    {
        Application.Quit();
    }



    public void OnClickLoadLevel()
    {
       
        int numberLevel = LevelSelection.instance.levelSelected + 1;
        Debug.Log("number level " + numberLevel);

        PlayerPrefs.SetInt("CurrentLevel", numberLevel);

        SceneManager.LoadScene("Level"+ numberLevel);
    }

}


