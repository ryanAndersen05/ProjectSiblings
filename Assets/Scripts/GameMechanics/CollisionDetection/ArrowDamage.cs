using UnityEngine;
using System.Collections;

public class ArrowDamage : DamageMechanics {
    Rigidbody2D rigid;
    ProjectileMechanics pMechanics;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pMechanics = GetComponent<ProjectileMechanics>();

    }
    public override void onDefaultEnter(Collider2D collider)
    {
        rigid.isKinematic = true;
        pMechanics.enabled = false;
    }
}
