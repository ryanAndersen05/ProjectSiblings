using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueOptionsUI : MonoBehaviour {
    public DialogueUI dialogueUI;
    public RectTransform[] optionPointerPositions;
    public RectTransform optionPointer;
    public Text optionText;
    public float pointerSpeed = 1.0f;

    int currentOptionAction = 0;
    OptionActionNode oActionNode;
    OptionNode oNode;
    int currentPosition = 0;
    bool moveCursor = true;

    void Update()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        bool actionDown = Input.GetButtonDown("Action");
        if (actionDown)
        {
            makeChoice();
            return;
        }
        if (Mathf.Abs(vInput) < .05f)
        {
            moveCursor = true;
        }
        if (Mathf.Abs(vInput) > .05f && moveCursor)
        {
            if (vInput > 0 && currentPosition > 0)
            {
                currentPosition--;
                moveCursor = false;
            }
            if (vInput < 0 && currentPosition < optionPointerPositions.Length - 1)
            {
                currentPosition++;
            }
        }
        shiftPointer();
    }

    public void openOptionMenu(OptionNode oNode)
    {
        this.currentPosition = 0;
        this.optionPointer.position = optionPointerPositions[currentPosition].position;
        this.oNode = oNode;
        this.oActionNode = dialogueUI.getNPCDialogue().actionNodes[currentOptionAction++];
        this.gameObject.SetActive(true);
        setOptionsMenu(oNode);
    }

    void makeChoice()
    {
        this.gameObject.SetActive(false);
        oNode.optionChosen = currentPosition;
        oNode.optionAction = oActionNode.optionActions[oNode.optionChosen];
        oNode.optionAction.setOptionUI(this);
        if (oNode.optionAction != null) oNode.optionAction.resetActionNode();
        dialogueUI.setCurrentNode(oNode.npcDialogueOptions[currentPosition]);
        dialogueUI.displayDialogue();

    }

    public void resetOptionsUI()
    {
        this.oNode = null;
        this.currentOptionAction = 0;
    }

    void setOptionsMenu(OptionNode oNode)
    {
        string text = "";
        int i = 0;
        foreach(string s in oNode.optionResponses)
        {
            i++;
            text += s;
            if (i < oNode.optionResponses.Length)
            {
                text += "\n\n";
            }
        }
        optionText.text = text;
    }

    void shiftPointer()
    {
        optionPointer.position = Vector3.Slerp(optionPointer.position,
            optionPointerPositions[currentPosition].position, Time.deltaTime / pointerSpeed);
    }

    public OptionNode getCurrentOptionNode()
    {
        return oNode;
    }
}
