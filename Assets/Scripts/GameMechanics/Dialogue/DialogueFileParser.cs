using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class DialogueFileParser {

	public static DialogueNode[] parseDialogueFile(string fileName)
    {
        List<DialogueNode> dNodes = new List<DialogueNode>();
        try
        {
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            string line = reader.ReadLine();
            while (line != null)
            {
                DialogueNode dNode = getDialogueNode(line);
                if (dNode != null)
                {
                    dNodes.Add(dNode);
                }
                line = reader.ReadLine();
            }
        } catch
        {
            Debug.Log("The file " + fileName + " is invlid");
        }
        DialogueNode[] allDialogueNodes = new DialogueNode[dNodes.Count];
        int i = 0;
        foreach (DialogueNode d in dNodes)
        {
            allDialogueNodes[i] = d;
            i++;
        }
        return allDialogueNodes;
    }

    private static DialogueNode getDialogueNode(string line)
    {
        string[] infoArray = line.Split('|');
        if (infoArray == null || infoArray.Length < 2) return null;
        string name = infoArray[0];
        string dialogue = infoArray[1];
        DialogueNode dNode = new DialogueNode();
        dNode.characterName = name;
        dNode.dialogueSegment = dialogue;
        return dNode;
    }
}
