using UnityEngine;
using System.Collections;

public class SummonItemMechanics : MonoBehaviour {
    public float coolDownTime = 5;
    ItemHandler itemHandler;
    Animator anim;
    float coolDownTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        itemHandler = GetComponent<ItemHandler>();
    }

    void Update()
    {
        coolDownTimer = Mathf.MoveTowards(coolDownTimer, 0, Time.deltaTime);
    }

    public void summonItem(bool buttonDown)
    {
        if (buttonDown && coolDownTimer <= 0 && itemHandler.useItem())
        {
            anim.SetTrigger("Summon");   
        }
    }
}
