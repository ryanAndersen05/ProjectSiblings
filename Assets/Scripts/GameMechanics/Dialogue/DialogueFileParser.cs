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
        while (line != null && line.CompareTo("END") != 0)
        {
            lineParts = line.Split('|');
            DialogueNode dNode = new DialogueNode();
            dNode.characterName = lineParts[0];
            if (lineParts.Length >= 2)
            {
                dNode.dialogueSegment = lineParts[1];
            }
            if (lineParts.Length >= 3)
            {
                dNode.characterEmotion = lineParts[2];
            }
            if (prevNode != null)
            {
                dNode.prevNode = prevNode;
                prevNode.nextNode = dNode;
            }
            prevNode = dNode;
            line = reader.ReadLine();
        }
        
        while(prevNode.prevNode != null)
        {
            prevNode = prevNode.prevNode;
        }

        return prevNode;
    }
}
