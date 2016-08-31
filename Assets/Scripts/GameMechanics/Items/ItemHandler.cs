using UnityEngine;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour {
    public int bagHeight = 1;
    public int bagWidth = 1;
    ItemNode[,] itemArray = new ItemNode[1, 1];

    void Start()
    {
        if (bagHeight > 1 || bagWidth > 1)
        {
            itemArray = new ItemNode[bagWidth, bagHeight];
        }
    }

    public bool addItem(Item i)
    {

        return true;
    }

    private ItemNode getItemAt(int i)
    {
        int x = 0;
        int y = 0;
        while ((y + 1) * bagWidth < i)
        {
            y++;
        }
        x = i - (y * bagWidth);
        return itemArray[x, y];
    }

    private class ItemNode
    {
        public int x;
        public int y;
        public int currentStack;
        public Item item;
        
        public bool addItem(Item i)
        {
            if (currentStack < i.maxPerStack)
            {
                return false;
            }
            currentStack++;
            return true;
        }

        public bool canUseItem()
        {
            if (currentStack <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
