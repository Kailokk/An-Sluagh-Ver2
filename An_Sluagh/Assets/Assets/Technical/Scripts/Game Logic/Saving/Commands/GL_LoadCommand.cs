using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Terminal/Commands/Load")]
public class GL_LoadCommand : AS_ActionsScript
{
    public override void Interaction()
    {
        string output = "Loading game...";
        V_AddTextEntry.Instance.CreateTextEntry(output);
        GL_SaveManager.LoadGame();
    }

}
