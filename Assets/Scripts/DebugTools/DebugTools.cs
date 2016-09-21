using UnityEngine;
using System.Collections;

public class DebugTools {

    public static string GetPathToObject(Transform t)
    {
        if (!t)
        {
            return null;
        }

        string path = t.name;
        while (t.parent != null)
        {
            t = t.parent;
            path = t.name + " -> " + path;
        }
        return path;
    }

    public static void printConversation(string fileName)
    {
        DialogueNode dNode = DialogueFileParser.parseDialogueFile(fileName);
        while (dNode != null)
        {
            Debug.Log(dNode);
            dNode = dNode.nextNode;
        }
    }
}
