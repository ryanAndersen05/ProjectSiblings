using UnityEngine;
using System.Collections;

public class OptionAction {

    private int countDownToAction = 1;
    private bool actionActive = false;

    public bool tickAction()
    {
        if (actionPerformed()) return false;
        if (countDownToAction-- <= 0)
        {
            performAction();
            actionActive = true;
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

    protected virtual void performAction()
    {

    }
}
