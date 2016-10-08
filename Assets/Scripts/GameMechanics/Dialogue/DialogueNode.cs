using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueNode {
    public string characterName;
    public string characterEmotion;
    public string dialogueSegment;
    public List<string> startActions = new List<string>();
    public List<string> endActions = new List<string>();
    public DialogueNode prevNode;
    public DialogueNode nextNode;
    public bool isLocalHead = false;
    public string originalFileName;

    public override string ToString()
    {
        return "Name: " + characterName + "\n" + 
            "Dialogue: " + dialogueSegment;
    }

    public void performStartActions()
    {
        foreach (string s in startActions)
        {
            DialogueActions.performDialogueActions(s, this);
        }
    }

    public void performEndActions()
    {
        foreach (string s in endActions)
        {
            DialogueActions.performDialogueActions(s, this);
        }
    }

    public DialogueNode getLocalHead()
    {
        if (prevNode == null || isLocalHead)
        {
            return this;
        }
        return this.prevNode.getLocalHead();
    }
}
