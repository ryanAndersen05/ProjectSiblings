﻿using UnityEngine;
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
                    
                    dNode = getOptionNode(parseOptionLines(reader, line));                    
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

    private static string[] parseOptionLines(StreamReader reader, string line)
    {
        List<string> lines = new List<string>();
        lines.Add(line.Substring(1));
        line = reader.ReadLine();
        while (line != null && line[0] != '!')
        {
            lines.Add(line);
            line = reader.ReadLine();
        }
        lines.Add(line.Substring(1));
        return lines.ToArray();
    }

    private static OptionNode getOptionNode(string[] lines)
    {
        OptionNode oNode = new OptionNode();
        
        oNode.optionResponses = splitOptions(lines[0], oNode);

        List<DialogueNode> responseNodes = new List<DialogueNode>();
        for (int i = 1; i < lines.Length; i++)
        {
            responseNodes.Add(getDialogueNode(lines[i]));
        }
        oNode.npcDialogueOptions = responseNodes.ToArray();
        return oNode;
    }

    private static string[] splitOptions(string line, OptionNode oNode)
    {
        List<string> allOptions = new List<string>();
        string[] splitOptions = line.Split('|');
        Debug.Log(splitOptions.Length);
        if (splitOptions.Length <= 0)
        {
            return null;
        }
        oNode.characterName = splitOptions[0];
        for (int i = 1; i < splitOptions.Length; i++)
        {
            allOptions.Add(splitOptions[i]);
        }
        return allOptions.ToArray();
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
