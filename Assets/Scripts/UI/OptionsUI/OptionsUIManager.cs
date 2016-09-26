using UnityEngine;
using System.Collections;

public class OptionsUIManager : MonoBehaviour {
    public OptionsUINode initialOptionNode;

    public const int NORTH = 0;
    public const int SOUTH = 1;
    public const int EAST = 2;
    public const int WEST = 3;

    OptionsUINode currentOptionNode;

    bool verticalMoveActive = true;
    bool horizontalMoveActive = true;

    void Start()
    {
        currentOptionNode = initialOptionNode;
        currentOptionNode.isCurrentNode = true;
    }

    void Update()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(vInput) < .15f)
        {
            verticalMoveActive = true;
        }
        else if (verticalMoveActive)
        {
            if (vInput > 0)
            {
                moveOptionsNode(NORTH);
            }
            else
            {
                moveOptionsNode(SOUTH);
            }
            verticalMoveActive = false;
        }
        if (Mathf.Abs(hInput) < .15f)
        {
            horizontalMoveActive = true;
        }
        else if (horizontalMoveActive)
        {
            if (hInput > 0)
            {
                moveOptionsNode(EAST);
            }
            else
            {
                moveOptionsNode(WEST);
            }
            horizontalMoveActive = false;
        }
    }

    public void setOptionNode(OptionsUINode oNode)
    {
        if (oNode == null) return;
        this.currentOptionNode.isCurrentNode = false;
        this.currentOptionNode = oNode;
        this.currentOptionNode.isCurrentNode = true;
    }

    private void moveOptionsNode(int direction)
    {
        OptionsUINode newNode = null;
        switch (direction)
        {
            case NORTH:
                newNode = this.currentOptionNode.northNode;
                break;
            case SOUTH:
                newNode = this.currentOptionNode.southNode;
                break;
            case EAST:
                newNode = this.currentOptionNode.eastNode;
                break;
            case WEST:
                newNode = this.currentOptionNode.westNode;
                break;
        }
        if (newNode)
        {
            setOptionNode(newNode);
        }
    }
}
