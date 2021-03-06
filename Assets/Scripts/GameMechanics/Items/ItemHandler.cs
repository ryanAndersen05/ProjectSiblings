﻿using UnityEngine;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour {
    public Item[] initialHeldItems = new Item[0];

    List<ItemNode> currentHeldItems = new List<ItemNode>();
    int currentItemSelected = 0;

    
    void Start()
    {
        foreach (Item i in initialHeldItems)
        {
            addItems(i);
        }
        
    }

    public bool addItems(Item item, int count = 1)
    {
        int itemIndex = -1;
        int checkIndex = 0;
        foreach (ItemNode i in currentHeldItems)
        {
            if (i.item.itemName == item.itemName)
            {
                itemIndex = checkIndex;
                break;
            }
            checkIndex++;
        }
        if (itemIndex < 0)
        {
            itemIndex = currentHeldItems.Count;
            currentHeldItems.Add(new ItemNode(item));
        }
        bool successfullyAdded = false;
        for (int i = 0; i < count; i++)
        {
            if (currentHeldItems[itemIndex].addItem())
            {
                successfullyAdded = true;
            }
            else break;
        }
        return successfullyAdded;
    }

    public Item useItem()
    {
        if (currentItemSelected >= currentHeldItems.Count || currentItemSelected < 0) return null;
        ItemNode i = currentHeldItems[currentItemSelected];
        i.useItem();
        if (i.currentStack <= 0)
        {
            currentHeldItems.Remove(i);
            selectItemDown();
        }
        return i.item;
    }

    public void selectItem(int index)
    {
        if (currentHeldItems.Count <= 1) return;
        while (index < 0)
        {
            index += currentHeldItems.Count;
        }
        currentItemSelected = index % currentHeldItems.Count;
    }

    public void selectItemUp()
    {
        selectItem(++currentItemSelected);
    }

    public void selectItemDown()
    {
        selectItem(--currentItemSelected);
    }

    public Item getCurrentItem()
    {
        if (currentItemSelected < 0 || currentItemSelected >= currentHeldItems.Count) return null;
        else return currentHeldItems[currentItemSelected].item;
    }

    private class ItemNode
    {
        public int currentStack;
        public Item item;
        
        public ItemNode(Item item)
        {
            this.item = item;
        }

        public bool addItem()
        {
            if (currentStack < item.maxPerStack)
            {
                return false;
            }
            currentStack++;
            return true;
        }

        public bool useItem()
        {
            if (currentStack <= 0) return false;
            currentStack--;
            return true;
        }
    }
}
