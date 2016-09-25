using UnityEngine;
using System.Collections;

public class OptionNode : DialogueNode {
    public string[] optionResponses;
    public DialogueNode[] npcDialogueOptions;
    public int optionChosen = 0;
    public OptionAction optionAction;

    public override string ToString()
    {
        string response = "Name: " + characterName + "\n";
        for (int i = 0; i < optionResponses.Length; i++)
        {
            response += "-> Option " + (i + 1) + ": " + optionResponses[i] + "\n";
            response += "NPC Response " + (i + 1)+ ":\n" + npcDialogueOptions[i].ToString() + "\n";
            response += "-------------------------------------------------------------------\n";
        }
        return response;
    }
}
