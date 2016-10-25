using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueUI : MonoBehaviour {
    DialogueNode currentDialogueNode;
    DialoguePlayer player;
    NPCDialogue npc;
    bool isActive;

    public bool activateDialogue(DialoguePlayer player, NPCDialogue npc)
    {
        if (isActive)
        {
            return false;
        }
        isActive = true;
        this.player = player;
        this.npc = npc;
        currentDialogueNode = DialogueFileParser.parseDialogueFile(npc.dialogueFileName);
        return true;
    }
}
