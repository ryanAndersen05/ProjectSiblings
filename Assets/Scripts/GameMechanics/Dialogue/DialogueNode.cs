using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueNode {
    public string characterName;
    public string dialogueSegment;
    public OptionAction[] startActions;
    public OptionAction[] endActions;
    public DialogueNode prevNode;
    public DialogueNode nextNode;

    public override string ToString()
    {
        return "Name: " + characterName + "\n" + 
            "Dialogue: " + dialogueSegment;
    }

    public OptionAction[] performStartActions()
    {
        return performActions(startActions);
    }

    public OptionAction[] performEndActions()
    {
        return performActions(endActions);
    }

    private OptionAction[] performActions(OptionAction[] actions)
    {
        List<OptionAction> activeActions = new List<OptionAction>();
        foreach (OptionAction oA in actions)
        {
            oA.performAction();
            if (oA.isActive)
            {
                activeActions.Add(oA);
            }
        }
        return activeActions.ToArray();
    }
}
