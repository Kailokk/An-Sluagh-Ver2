using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AS_ActionsScript : ScriptableObject
{

   public string[] actionWords;

    //Inherit me and create the specific script for the action in question
    public abstract void Interaction();

}
