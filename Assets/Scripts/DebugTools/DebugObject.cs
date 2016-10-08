using UnityEngine;
using System.Collections;

public class DebugObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Tab))
        {
            DialogueNode dNode = DialogueFileParser.parseDialogueFile("/DialogueScripts/TestDialogue.txt", "A");
            while(dNode != null)
            {
                Debug.Log(dNode);
                dNode = dNode.nextNode;
            }
        }
	}
}
