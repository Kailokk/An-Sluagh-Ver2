using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Interaction/Take")]
public class AS_Interaction_take : AS_InteractionScript
{

    public override void Interaction(AS_ObjectScript obj)
    {
        GL_Event_Manager.Instance.AddToInventory(obj);
        GL_GameController.Instance.ReloadItemsAndEntrances();
        V_AddTextEntry.Instance.CreateTextEntry(this.interactionDescription);
    }


    public override void Interaction(AS_EntranceScript entrance)
    {

    }

}
