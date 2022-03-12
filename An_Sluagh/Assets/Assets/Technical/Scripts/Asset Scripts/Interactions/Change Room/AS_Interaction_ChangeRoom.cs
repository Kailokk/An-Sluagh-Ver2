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
        V_AddTextEntry.Instance.CreateTextEntry();

        if (CheckCinematicOrRoom(entranceScript))
        {
            GL_GameController.Instance.LoadNextCinematic(entranceScript.cinematic);
            return;
        }

        GL_GameController.Instance.LoadNewRoom(entranceScript.room);
    }


    private bool CheckCinematicOrRoom(AS_EntranceScript entranceScript)
    {
        if (entranceScript.room == null && entranceScript.cinematic != null)
        {
            return true;
        }
        if (entranceScript.cinematic == null && entranceScript.room != null)
        {
            return false;
        }

        Debug.LogError("Could not find cinematic or room to load");

        V_AddTextEntry.Instance.LogError("No valid room or cinematic found");
        return false;
    }


}
