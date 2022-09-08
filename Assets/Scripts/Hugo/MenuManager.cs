using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameDifficulty gameDifficulty;

    public void SelectGameA()
    {
        gameDifficulty.easyModeSelected = true;
        SceneManager.LoadScene(1);
    }

    public void SelectGameB()
    {
        gameDifficulty.easyModeSelected = false;
        SceneManager.LoadScene(1);
    }

}
