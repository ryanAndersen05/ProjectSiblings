using UnityEngine;
using System.Collections;

public class OpenNewThread : OptionAction {
    public string fileName;
    protected override void performAction()
    {
        DialogueNode dNode = DialogueFileParser.parseDialogueFile(fileName);
        optionsUI.dialogueUI.setCurrentNode(dNode);
    }
}
