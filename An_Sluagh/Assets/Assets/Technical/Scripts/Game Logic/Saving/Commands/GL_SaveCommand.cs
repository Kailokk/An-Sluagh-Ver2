using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Terminal/Commands/Save")]
public class GL_SaveCommand : AS_ActionsScript
{
    public override void Interaction()
    {

        string output = "Saving game...";
        V_AddTextEntry.Instance.CreateTextEntry(output);
        GL_SaveManager.SaveGame();
        output = "Game saved.";
        V_AddTextEntry.Instance.CreateTextEntry(output);
    }


}
