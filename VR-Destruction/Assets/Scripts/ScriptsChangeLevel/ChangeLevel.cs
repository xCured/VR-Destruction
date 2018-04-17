using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour {

    //public int SceneIndex =  SceneManager.GetActiveScene().buildIndex +1;


    // int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
    //SceneManager.LoadScene(nextBuildIndex);
    //public void Nextlevel()
    //{
    //    SceneManager.LoadScene(SceneIndex);
    //}

    public void ReturnMenu()
    {
        SceneManager.LoadScene("UIlevel");

    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Timer.timeLeft = 60;
        Timer.started = false;

    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void ObjDeleter()
    {
        Destroy(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
