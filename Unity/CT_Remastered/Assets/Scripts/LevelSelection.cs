using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LevelsList
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}

public class LevelSelection : MonoBehaviour
{

    //public bool levelSelected;

    public int levelAvailable = 0;
    public int levelSelected = -1;

    public Button buttonPlay;
    public Button[] buttonLevels;
 
    public Text LevelInfo;

    void Awake()
    {
        //levelSelected = false;
        levelSelected = -1;

    }

    public void OnClickLevel(int i)
    {
        levelSelected = i;     
    }

    private void Update()
    {
        for (int i=0;i<buttonLevels.Length; i++)
        {
            buttonLevels[i].interactable = (i <= levelAvailable);
        }

        if (levelSelected >= 0)
        {

            LevelInfo.text = "Level " + (levelSelected+1);
            buttonPlay.gameObject.SetActive(true);
        }
        else
        {
            buttonPlay.gameObject.SetActive(false);
        }
        //switch (LevelsList)

        //{
        //    case LevelsList.Level1:

        //        break;

        //    case LevelsList.Level2:

        //        break;

        //    case LevelsList.Level3:

        //        break;

        //    case LevelsList.Level4:

        //        break;

        //    case LevelsList.Level5:

        //        break;

        //}
    }
}
