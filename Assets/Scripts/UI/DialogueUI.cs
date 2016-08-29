using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueUI : MonoBehaviour {
    public Image portraitRight;
    public Image portraitLeft;
    public Image nameBoxRight;
    public Image nameBoxLeft;
    public Image dialogueBox;
    public Text dialogueText;
    public Text nameLeft;
    public Text nameRight;

    public bool isActive;
    public bool isRight;
    DialogueNode[] dNodes;
    int currentDialogueSegment = 0;

    public void activateConversation(string fileName)
    {
        dNodes = DialogueFileParser.parseDialogueFile(fileName);
        foreach (DialogueNode d in dNodes)
        {
            print(d.characterName);
        }
        dialogueBox.gameObject.SetActive(true);
        dialogueText.text = dNodes[0].dialogueSegment;
        nameBoxLeft.gameObject.SetActive(true);
        nameLeft.text = dNodes[0].characterName;
        isActive = true;
        currentDialogueSegment = 0;
    }

    void Update()
    {
        if (isActive && Input.GetButtonDown("Action"))
        {
            nextDialogue();
        }
    }

    void nextDialogue()
    {
        currentDialogueSegment++;
        if (currentDialogueSegment >= dNodes.Length)
        {
            isActive = false;
            dialogueBox.gameObject.SetActive(false);
            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(false);
            return;
        }
        if (dNodes[currentDialogueSegment].characterName != dNodes[currentDialogueSegment - 1].characterName)
        {
            isRight = !isRight;
        }
        print(isRight);
        
        if (isRight)
        {
            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(true);
            nameRight.text = dNodes[currentDialogueSegment].characterName;
        }
        else
        {
            nameBoxRight.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(true);
            nameLeft.text = dNodes[currentDialogueSegment].characterName;
        }
        dialogueText.text = dNodes[currentDialogueSegment].dialogueSegment;
    }

}
