using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Terminal/Interaction/Examine")]
public class AS_Interaction_examine : AS_InteractionScript
{

    public override string[] actionWords
    {
        get {
            
             string[] defaultActionWords = new string[] {"examine", "EXAMINE","Examine"}; 
             string[] appendedActionWords= defaultActionWords.Concat(ActionWords).ToArray();
             return appendedActionWords;
            }
    }

    public override void Interaction(AS_ObjectScript obj)
    {
        V_AddTextEntry.Instance.CreateTextEntry(interactionDescription);
    }

    public override void Interaction(AS_EntranceScript entrance)
    {

    }

}
