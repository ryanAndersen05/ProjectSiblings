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
    public float coolDownTime = .02f;
    public float coolDownTimeEnd = 1;
    public DialogueOptionsUI optionsUI;
    public float coolDownTimer = 0;
    DialogueNode currentNode;
    Dialogue player;
    NPCDialogue npc;

    public bool activateConversation(NPCDialogue npc, Dialogue player)
    {
        if (coolDownTimer > 0) return false;
        this.player = player;
        this.npc = npc;
        string fileName = npc.dialogueFileName;
        optionsUI.resetOptionsUI();
        currentNode = DialogueFileParser.parseDialogueFile(fileName);
        dialogueBox.gameObject.SetActive(true);
        dialogueText.text = currentNode.dialogueSegment;
        nameBoxLeft.gameObject.SetActive(true);
        nameLeft.text = currentNode.characterName;
        isActive = true;
        coolDownTimer = coolDownTime;
        return true;
    }

    void Update()
    {
        if (optionsUI.isActiveAndEnabled) return;
        if (isActive && Input.GetButtonDown("Action") && coolDownTimer <= 0)
        {
            nextDialogue();
        }
        coolDownTimer = Mathf.MoveTowards(coolDownTimer, 0, Time.deltaTime);
    }

    public void nextDialogue()
    {
        if (checkOptionActionActive()) return;
        currentNode = currentNode.nextNode;
        displayDialogue();
        
    }

    bool checkOptionActionActive()
    {
        if (optionsUI.getCurrentOptionNode() == null) return false;
        OptionNode oNode = optionsUI.getCurrentOptionNode();
        if (oNode.optionAction == null) return false;
        oNode.optionAction.tickAction();
        if (oNode.optionAction.isActive()) return true;
        return false;
    }

    public void displayDialogue()
    {
        if (currentNode == null)
        {
            isActive = false;
            dialogueBox.gameObject.SetActive(false);
            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(false);
            coolDownTimer = coolDownTimeEnd;
            player.endDialogue();
            return;
        }
        if (currentNode is OptionNode)
        {
            optionsUI.openOptionMenu((OptionNode)currentNode);
            return;
        }
        if (currentNode.characterName != currentNode.prevNode.characterName)
        {
            isRight = !isRight;
        }

        if (isRight)
        {

            nameBoxLeft.gameObject.SetActive(false);
            nameBoxRight.gameObject.SetActive(true);
            nameRight.text = currentNode.characterName;
        }
        else
        {

            nameBoxRight.gameObject.SetActive(false);
            nameBoxLeft.gameObject.SetActive(true);
            nameLeft.text = currentNode.characterName;
        }
        //print(dNodes[currentDialogueSegment].characterName + ":" + dNodes[currentDialogueSegment].dialogueSegment);
        dialogueText.text = currentNode.dialogueSegment;
        coolDownTimer = coolDownTime;
    }

    public void setCurrentNode(DialogueNode dNode)
    {
        dNode.prevNode = this.currentNode;
        this.currentNode = dNode;
    }

    public NPCDialogue getNPCDialogue()
    {
        return npc;
    }
}
