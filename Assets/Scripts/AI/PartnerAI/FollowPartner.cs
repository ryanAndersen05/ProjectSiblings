using UnityEngine;
using System.Collections;

public class FollowPartner : State {
    public Transform partnerTransform;
    public float threshold;
    Transform aiParent;
    MovementMechanics aiMovementMechanics;

    public override void enterState(AIStateMachine stateMachine)
    {
        base.enterState(stateMachine);
        aiParent = stateMachine.getParent();
        print(aiParent.name);
        if (partnerTransform == null)
        {
            partnerTransform = GameObject.FindObjectOfType<PlayerController>().getCurrentPlayer();
        }
        if (aiMovementMechanics == null)
        {
            aiMovementMechanics = aiParent.GetComponent<MovementMechanics>();
        }
    }

    public override void updateState()
    {
        float xDistance = aiParent.position.x - partnerTransform.position.x;
        if (Mathf.Abs(xDistance) > threshold)
        {
            if (xDistance < 0)
            {
                aiMovementMechanics.setHorizontalInput(1);
            }
            else
            {
                aiMovementMechanics.setHorizontalInput(-1);
            }
        }
        else
        {
            aiMovementMechanics.setHorizontalInput(0);
        }
    }
}
