using System;
using System.Collections.Generic;
using UnityEngine;

public class GL_Event_Manager : MonoBehaviour
{
    private static GL_Event_Manager _instance;
    public static GL_Event_Manager Instance { get { return _instance; } }
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



    //Adds an item to the inventory
    public event Action<AS_ObjectScript> onAddToInventory;
    public void AddToInventory(AS_ObjectScript objectScript)
    {
        if (onAddToInventory != null)
        {
            onAddToInventory(objectScript);
        }
    }

    //Adds an item to the inventory
    public event Action<AS_ObjectScript> onRemoveFromInventory;
    public void RemoveFromInventory(AS_ObjectScript objectScript)
    {
        if (onAddToInventory != null)
        {
            onAddToInventory(objectScript);
        }
    }



    //Called when the terminal is shut down, to save and play sound/visual effects
    public event Action onTerminalShutdown;
    public void TerminalShutdown()
    {
        if (onTerminalShutdown != null)
        {
            onTerminalShutdown();
        }

    }
    //need some function to actually end the game 


}
