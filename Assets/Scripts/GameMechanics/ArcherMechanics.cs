using UnityEngine;
using System.Collections;

public class ArcherMechanics : MonoBehaviour {
    public float maxChargeTime;
    public float coolDownTime = 1;
    public Transform launchLocation;
    public GameObject arrowObject;
    ProjectileMechanics[] arrows;
    int currentArrow;
    const int totalArrows = 10;
    float chargeTimer = 0;
    float coolDownTimer;
    bool bowDown;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        arrows = new ProjectileMechanics[10];
        for (int i = 0; i < totalArrows; i++)
        {
            arrows[i] = ((GameObject)Instantiate(arrowObject, Vector3.zero, new Quaternion())).GetComponent<ProjectileMechanics>();
            arrows[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        coolDownTimer = Mathf.MoveTowards(coolDownTimer, 0, Time.deltaTime);
        if (bowDown && coolDownTimer <= 0)
        {
            chargeTimer = Mathf.MoveTowards(chargeTimer, maxChargeTime, Time.deltaTime);
        }
        else if (chargeTimer > 0)
        {
            fireBow();
            coolDownTimer = coolDownTime;
            chargeTimer = 0;
        }
        else
        {
            chargeTimer = 0;
        }
    }

    public void chargeBow(bool bowDown)
    {
        this.bowDown = bowDown;
    }

    void fireBow()
    {
        ProjectileMechanics a = arrows[currentArrow];
        currentArrow = (currentArrow + 1) % totalArrows;
        a.transform.position = launchLocation.position;

        a.setUpLaunch(a.maxLaunchForce * (.2f + .8f * chargeTimer / maxChargeTime), (transform.localScale.x > 0) ? 180 : 0);
        a.gameObject.SetActive(true);
        a.launchArrow();
        
    }
}
