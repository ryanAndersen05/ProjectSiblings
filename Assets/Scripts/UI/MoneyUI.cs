using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {
    public Text moneyText;
    MoneyManager mManager;

    void Start()
    {
        mManager = GameObject.FindObjectOfType<MoneyManager>();
    }

    void Update()
    {
        moneyText.text = "x" + mManager.currentMoney;
    }
}
