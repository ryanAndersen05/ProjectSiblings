using UnityEngine;
using System.Collections;

public class OptionAction : MonoBehaviour {
    public int actionCount = 1;
    private int countDownToAction = 1;
    private bool actionActive = false;

    public bool tickAction()
    {
        if (actionPerformed()) return false;
        if (countDownToAction-- <= 0)
        {
            actionActive = true;
            performAction();
            return true;
        }
        return false;
    }

    public void setAction(int countDownToAction)
    {
        this.countDownToAction = countDownToAction;
    }

    public bool isActive()
    {
        return this.actionActive;
    }

    public bool actionPerformed()
    {
        return countDownToAction < 0;
    }

    public void resetActionNode()
    {
        this.countDownToAction = actionCount;
        this.actionActive = false;
    }

    protected virtual void performAction()
    {
        countDownToAction = -1;
        actionActive = false;
    }
}
