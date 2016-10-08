using UnityEngine;
using System.Collections;

public class DialogueActions
{
    public static void performDialogueActions(string action, DialogueNode currentNode)
    {
        string[] actionParts = action.Split(' ');
        switch (actionParts[0])
        {
            case "OPENSECTION":
                addNewSection(actionParts, currentNode);
                break;
        }
    }

    protected static void addNewSection(string[] actionParts, DialogueNode currentNode)
    {
        string fileName = currentNode.getLocalHead().originalFileName;
        currentNode.nextNode = DialogueFileParser.parseDialogueFile(fileName, actionParts[1]);
    }
}
