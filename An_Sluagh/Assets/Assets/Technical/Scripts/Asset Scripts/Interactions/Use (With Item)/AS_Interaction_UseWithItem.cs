using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Terminal/Interaction/Use (With Item)")]
public class AS_Interaction_UseWithItem : AS_InteractionScript
{

    //store in used items list
    //remove item from inventory

    public override void Interaction(AS_ObjectScript obj)
    {

        if (G_InteractionTracker.Instance.CheckInteraction(obj))
        {
            return;
        }

        foreach (AS_ObjectScript objectScript1 in interactionObjects)
        {
            if (!GL_Inventory.Instance.CheckForItem(objectScript1))
            {
                V_AddTextEntry.Instance.LogError("You do not have the items needed to take this action");
                return;
            }
        }


        foreach (AS_ObjectScript objectScript in interactionObjects)
        {
            G_InteractionTracker.Instance.LogItemUsed(objectScript);

            GL_Event_Manager.Instance.RemoveFromInventory(objectScript);
        }

        G_InteractionTracker.Instance.LogInteraction(obj);
        V_AddTextEntry.Instance.CreateTextEntry(interactionDescription);

        if (shouldAddItemToInventory)
        {
            GL_Event_Manager.Instance.AddToInventory(obj.subObject);
        }

        GL_GameController.Instance.ReloadItemsAndEntrances();

    }

    public override void Interaction(AS_EntranceScript entrance)
    {
        if (G_InteractionTracker.Instance.CheckInteraction(entrance))
        {
            return;
        }

        foreach (AS_ObjectScript objectScript1 in interactionObjects)
        {
            if (!GL_Inventory.Instance.CheckForItem(objectScript1))
            {
                V_AddTextEntry.Instance.LogError("You do not have the items needed to take this action");
                return;
            }
        }

        foreach (AS_ObjectScript objectScript in interactionObjects)
        {
            G_InteractionTracker.Instance.LogItemUsed(objectScript);

            GL_Event_Manager.Instance.RemoveFromInventory(objectScript);
        }

        G_InteractionTracker.Instance.LogInteraction(entrance);
        V_AddTextEntry.Instance.CreateTextEntry(interactionDescription);
        GL_GameController.Instance.ReloadItemsAndEntrances();

    }


    public bool shouldAddItemToInventory;


}
