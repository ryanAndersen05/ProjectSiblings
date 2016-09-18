using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {
    public int value = 1;


    void OnTriggerEnter2D (Collider2D collider)
    {
        MoneyManager mManager = collider.GetComponent<MoneyManager>();
        if (mManager != null)
        {
            mManager.addMoney(value);
            Destroy(this.gameObject);
        }
    }
}
