using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenUI : MonoBehaviour {
    public string startActionScene = "WinterScene";

    public void onStartGamePressed()
    {
        SceneManager.LoadScene(startActionScene);
    }

    public void onQuitGamePressed()
    {
        Application.Quit();
    }

    public void onSettingsPressed()
    {


    }
}
