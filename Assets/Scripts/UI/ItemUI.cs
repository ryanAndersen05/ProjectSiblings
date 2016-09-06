using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemUI : MonoBehaviour {
    public Image itemImage;
    ItemHandler itemHandler;

    void Start()
    {
        itemHandler = GameObject.FindObjectOfType<ItemHandler>();
        if (!itemHandler)
        {
            this.enabled = false;
            print("No Item Handler Found in scene");
        }
        else
        {
            updateImage();
        }
    }

    void Update()
    {
        bool itemUp = Input.GetButtonDown("ItemUp");
        bool itemDown = Input.GetButtonDown("ItemDown");

        if (itemUp)
        {
            itemHandler.selectItemUp();
            updateImage();
        }
        if (itemDown)
        {
            itemHandler.selectItemDown();
            updateImage();
        }
    }

    void updateImage()
    {
        Item i = itemHandler.getCurrentItem();
        if (!i)
        {
            itemImage.sprite = null;
        }
        else
        {
            SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
            itemImage.sprite = sr.sprite;
            itemImage.color = sr.color;
        }
    }
}
