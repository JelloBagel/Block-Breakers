using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

    public void LoadLevel (string name)
    {
        Debug.Log("Level load requested: " + name);
        SceneManager.LoadScene(name);
        Brick.breakableCount = 0;
    }

    public void QuitRequest ()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel ()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
