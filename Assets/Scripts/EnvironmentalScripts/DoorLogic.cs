using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorLogic : MonoBehaviour {
    public int doorID = 1;
    public string sceneToOpen = "WinterScene";
    bool doorActive = false;

    void Update()
    {
        if (!doorActive) return;
        if (Input.GetButtonDown("Action"))
        {
            openDoor();
        }
    }
    
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            doorActive = true;

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            doorActive = false;
        }
    }

    void openDoor()
    {
        PlayerSpawn.playerSpawn = doorID;
        SceneManager.LoadScene(sceneToOpen);
    }
}
