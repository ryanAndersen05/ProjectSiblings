using UnityEngine;
using System.Collections;

public class ScaredMechanics : MonoBehaviour {
    public float recoverMultiplier = 1;
    public const float DefaultRecoverTime = 10; //Time in seconds
    float currentRecoverTime;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();
	}

    void Update()
    {
        if (currentRecoverTime <= 0) return;
        currentRecoverTime = Mathf.MoveTowards(currentRecoverTime, 0, Time.deltaTime * recoverMultiplier);
        if (currentRecoverTime <= 0)
        {
            recoverCharacter();
        }

    }
	
	public void scareCharacter(float recoverTime = DefaultRecoverTime)
    {
        this.enabled = true;
        currentRecoverTime = recoverTime;
        anim.ResetTrigger("Recover");
        anim.SetTrigger("Scare");
    }

    public bool isScared()
    {
        return currentRecoverTime > 0;
    }

    public void recoverCharacter()
    {
        anim.ResetTrigger("Scare");
        anim.SetTrigger("Recover");
        this.enabled = false;
    }
}
