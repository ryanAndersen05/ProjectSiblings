using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
    public float activeDistance = 100;
    Transform target;
    FlipSprite fSprite;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fSprite = GetComponent<FlipSprite>();
    }

    void Update()
    {
        float distance = transform.position.x - target.position.x;
        if (Mathf.Abs(distance) > activeDistance) return;
        if (distance < 0)
        {
            fSprite.isRight = true;
        }
        else
        {
            fSprite.isRight = false;
        }
    }
}
