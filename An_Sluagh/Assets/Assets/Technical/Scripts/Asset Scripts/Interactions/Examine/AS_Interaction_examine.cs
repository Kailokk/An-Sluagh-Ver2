using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Interaction/Examine")]
public class AS_Interaction_examine : AS_InteractionScript
{

    public override void Interaction(AS_ObjectScript obj)
    {
        V_AddTextEntry.Instance.CreateTextEntry(this.interactionDescription);
    }

    public override void Interaction(AS_EntranceScript entrance)
    {

    }

}
