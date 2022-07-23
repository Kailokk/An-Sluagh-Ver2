using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AS_InteractionScript : ScriptableObject
{
    //The word/s used to engage the interaction
    public string[] ActionWords;

    public abstract string[] actionWords
    {
        get;
    }

    //The description of what happens 
    [TextArea]
    public string interactionDescription;

    //The list of potential pre-requisite objects for the interaction (present in inventory)
    public AS_ObjectScript[] interactionObjects;

    public abstract void Interaction(AS_ObjectScript obj);

    public abstract void Interaction(AS_EntranceScript entrance);



}
