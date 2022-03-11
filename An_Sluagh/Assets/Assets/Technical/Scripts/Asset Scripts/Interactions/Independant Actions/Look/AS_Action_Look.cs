using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Action/Look")]
public class AS_Action_Look : AS_ActionsScript
{
    public override void Interaction()
    {
        GL_GameController.Instance.ReloadCurrentRoom();
    }
}
