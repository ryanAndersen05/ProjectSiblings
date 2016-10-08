using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class DialogueFileParser {
    protected static string line;

	public static DialogueNode parseDialogueFile(string fileName, string section = null)
    {
        DialogueNode headNode = null;
        line = null;
        int i = 1;
        try
        {
            StreamReader reader = new StreamReader(Application.dataPath + fileName, Encoding.Default);
            headNode = buildSectionDialogue(reader, section);
            headNode.originalFileName = fileName;
            reader.Close();
        } catch
        {
            if (line == null) 
                Debug.Log("The file " + fileName + " is invalid");
            else
            {
                Debug.Log("Syntax Error at line " + i + ":\n\t" + line);
            }
        }
        return headNode;
    }

    public static DialogueNode buildSectionDialogue(StreamReader reader, string section)
    {
        line = reader.ReadLine();
        
        string[] lineParts = null;
        while (line != null)
        {
            lineParts = line.Split(' ');
            if (lineParts[0] == "BEGIN")
            {
                if (section == null)
                {
                    break;
                }
                if (lineParts[1] == section)
                {
                    break;
                }
            }
            line = reader.ReadLine();
        }
        line = reader.ReadLine();
        DialogueNode prevNode = null;
        DialogueNode currentNode = new DialogueNode();
        while (line != null && line.CompareTo("END") != 0)
        {
            if (line.Length > 0 && line[0] == '\t')
            {
                
                line = line.Substring(1, line.Length - 1);
            }
            else
            {
                if (currentNode != null)
                {
                    prevNode = currentNode;
                }
                currentNode = new DialogueNode();
            }
            switch(line[0])
            {
                case '+':
                    currentNode.startActions.Add(line.Substring(1, line.Length - 1));
                    break;
                case '-':
                    currentNode.endActions.Add(line.Substring(1, line.Length - 1));
                    break;
                default:
                    lineParts = line.Split('|');
                    currentNode.characterName = lineParts[0];
                    if (lineParts.Length > 1)
                    {
                        currentNode.dialogueSegment = lineParts[1];
                    }
                    if (lineParts.Length > 2)
                    {
                        currentNode.characterEmotion = lineParts[2];
                    }
                    break;
            }
            line = reader.ReadLine();
        }
        while(currentNode.prevNode != null)
        {
            currentNode = currentNode.prevNode;
        }

        return currentNode;
    }
}
