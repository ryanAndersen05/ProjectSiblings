using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {
    public int maxMoney = 10000;
    public int currentMoney = 150;

    public void loseMoney(int moneyLost)
    {
        currentMoney -= moneyLost;
        if (currentMoney < 0)
        {
            currentMoney = 0;
        }
    }

    public bool checkHasEnoughMoney(int checkAmount)
    {
        return currentMoney - checkAmount >= 0;
    }

    public bool addMoney(int moneyAdd)
    {
        if (currentMoney >= maxMoney) return false;
        currentMoney += moneyAdd;
        if (currentMoney > maxMoney) currentMoney = maxMoney;
        return true;
    }
}
