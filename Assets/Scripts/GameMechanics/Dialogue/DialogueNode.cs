using UnityEngine;
using System.Collections;

public class DialogueNode {
    public string characterName;
    public string dialogueSegment;
    public DialogueNode prevNode;
    public DialogueNode nextNode;

    public override string ToString()
    {
        return "Name: " + characterName + "\n" + 
            "Dialogue: " + dialogueSegment;
    }
}
