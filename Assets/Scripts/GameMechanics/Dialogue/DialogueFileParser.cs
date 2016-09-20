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
            StreamReader reader = new StreamReader(Application.dataPath + fileName, Encoding.Default);
            string line = reader.ReadLine();
            while (line != null)
            {

                DialogueNode dNode = null;
                if (line.Length > 0 && line[0] == '!')
                {
                    dNode = getOptionNode(line);
                }
                else
                {
                    dNode = getDialogueNode(line);
                }
                if (dNode != null)
                {
                    dNodes.Add(dNode);
                }
                line = reader.ReadLine();
            }
        } catch
        {
            Debug.Log("The file " + fileName + " is invalid");
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

    private static OptionNode getOptionNode(string line)
    {
        OptionNode oNode = new OptionNode();
        string parseString = line.Substring(1, line.Length);
        string[] infoArray = parseString.Split('|');
        oNode.characterName = infoArray[0];
        for (int i = 1; i < infoArray.Length; i++)
        {

        }
        return oNode;
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
