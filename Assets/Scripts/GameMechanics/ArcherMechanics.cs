using UnityEngine;
using System.Collections;

public class ArcherMechanics : MonoBehaviour {
    public float maxChargeTime;
    public Transform launchLocation;
    public GameObject arrowObject;
    ProjectileMechanics[] arrows;
    int currentArrow;
    const int totalArrows = 10;
    float chargeTimer = 0;
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
        if (bowDown)
        {
            chargeTimer += Time.deltaTime;
        }
        else if (chargeTimer > 0)
        {
            chargeTimer = 0;
            fireBow();
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
        a.gameObject.SetActive(true);
        
    }
}
