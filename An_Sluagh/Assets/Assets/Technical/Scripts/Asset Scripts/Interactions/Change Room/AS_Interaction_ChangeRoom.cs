using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Interaction/Change Room")]
public class AS_Interaction_ChangeRoom : AS_InteractionScript
{

    public override void Interaction(AS_ObjectScript obj)
    {
    }


    public override void Interaction(AS_EntranceScript entranceScript)
    {
        V_AddTextEntry.Instance.CreateTextEntry(this.interactionDescription);
        GL_GameController.Instance.LoadNewRoom(entranceScript.room);
    }

}
