using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_InteractionTracker : MonoBehaviour
{
    //log items/entrances that are interacted with, make a case when displaying room to check if the item appears here or the inventory  

    private static G_InteractionTracker _instance;
    public static G_InteractionTracker Instance { get { return _instance; } }
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



    //A list of objects that have been interacted with
    private List<AS_ObjectScript> objectInteractionList = new List<AS_ObjectScript>();
    //A list of entrances that have been interacted with.
    private List<AS_EntranceScript> EntranceInteractionList = new List<AS_EntranceScript>();

    //logs an object that has been interacted with
    private void LogInteraction(AS_ObjectScript objectScript)
    {
        objectInteractionList.Add(objectScript);
    }

    //logs an entrance that has been interacted with
    private void LogInteraction(AS_EntranceScript entrance)
    {
        EntranceInteractionList.Remove(entrance);
    }

    //checks if an object has been interacted with, and returns true if it has
    public bool CheckInteraction(AS_ObjectScript objectScript)
    {
        return objectInteractionList.Contains(objectScript);
    }

    //Checks if an entrance has been interacted with, and returns true if it has
    public bool CheckInteraction(AS_EntranceScript entrance)
    {
        return EntranceInteractionList.Contains(entrance);
    }

}
