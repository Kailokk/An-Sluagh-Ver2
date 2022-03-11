using System;
using System.Collections.Generic;
using UnityEngine;

public class GL_Inventory : MonoBehaviour
{
    private static GL_Inventory _instance;
    public static GL_Inventory Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    //Signs the inventory up to the events adding or removing items
    private void Start()
    {
        GL_Event_Manager.Instance.onAddToInventory += addItem;
        GL_Event_Manager.Instance.onRemoveFromInventory += removeItem;
    }



    //Inventory
    private List<AS_ObjectScript> Inventory = new List<AS_ObjectScript>();


    //adds an item when the event is called
    private void addItem(AS_ObjectScript objectScript)
    {
        Inventory.Add(objectScript);
    }

    //removes an item when the event is called, or logs an error if it cant
    private void removeItem(AS_ObjectScript objectScript)
    {
        if (Inventory.Contains(objectScript))
        {
            Inventory.Remove(objectScript);
        }
        else { Debug.LogError("Item removed from inventory that did not exist in inventory"); }
    }



    //checks the inventory for the item
    public bool CheckForItem(AS_ObjectScript objectScript)
    {
        return Inventory.Contains(objectScript);
    }


}