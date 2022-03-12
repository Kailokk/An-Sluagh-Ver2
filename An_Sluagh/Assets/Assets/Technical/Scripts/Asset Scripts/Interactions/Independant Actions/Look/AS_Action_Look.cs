using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Action/Look")]
public class AS_Action_Look : AS_ActionsScript
{
    public override void Interaction()
    {
        V_AddTextEntry.Instance.CreateTextEntry("You re-examine your surroundings.");
        V_AddTextEntry.Instance.CreateTextEntry();
        GL_GameController.Instance.ReloadCurrentRoom();
    }
}
