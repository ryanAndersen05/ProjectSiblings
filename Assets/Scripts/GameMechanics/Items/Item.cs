using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public int maxPerStack = 5;
    public string itemName = "Item";
    public Sprite sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

}
