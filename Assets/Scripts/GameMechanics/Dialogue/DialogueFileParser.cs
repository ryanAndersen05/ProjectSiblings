using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class DialogueFileParser {

	public static DialogueNode parseDialogueFile(string fileName)
    {
        DialogueNode headNode = new DialogueNode();
        DialogueNode currentNode = headNode;
        try
        {
            StreamReader reader = new StreamReader(Application.dataPath + fileName, Encoding.Default);
            string line = reader.ReadLine();
            while (line != null)
            {
                DialogueNode dNode = constructDialogueNode(line);
                line = reader.ReadLine();
            }
            reader.Close();
        } catch
        {
            Debug.Log("The file " + fileName + " is invalid");
        }
       
        return headNode.nextNode;
    }

    private static DialogueNode constructDialogueNode(string line)
    {
        return null;
    }
}
