using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Action/Inventory")]
public class AS_Action_Inventory : AS_ActionsScript
{

    public override void Interaction()
    {

        string preface = "You currently have: \n";

        preface += GL_Inventory.Instance.ReturnInventoryList();

        V_AddTextEntry.Instance.CreateTextEntry(preface);

    }

}
