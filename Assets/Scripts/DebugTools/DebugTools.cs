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
        DialogueNode[] dNodes = DialogueFileParser.parseDialogueFile(fileName);
        foreach (DialogueNode d in dNodes)
        {
            Debug.Log(d);
        }
    }
}
