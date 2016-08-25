using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;
	public Transform[] pauseComponents = new Transform[0];

    public void pauseGame()
    {
        isPaused = !isPaused;
        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;

		foreach (Transform t in pauseComponents) 
		{
			t.gameObject.SetActive(isPaused);
		}

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
        }
    }
}
