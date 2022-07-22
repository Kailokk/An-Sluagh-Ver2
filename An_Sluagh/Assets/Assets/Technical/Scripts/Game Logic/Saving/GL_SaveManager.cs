using UnityEngine;
using System.Collections.Generic;
public class GL_SaveManager : MonoBehaviour
{

    private static GL_SaveData saveData = new GL_SaveData();
    private static void Start()
    {
        saveData = new GL_SaveData();
    }

    public static void SaveGame()
    {
        SaveInventory();

        GL_SerialisationManager.Save("save", saveData);
        Debug.Log("Game Saved");
    }

    public static void LoadGame()
    {
        saveData = (GL_SaveData)GL_SerialisationManager.Load(Application.persistentDataPath + "/saves/Save.save");

        if (saveData.inventory == null)
        {
            Debug.LogError("Savedata was null");
        }

        LoadInventory();

        //to test if inventory is properly implemented
        GL_GameController.Instance.ReloadCurrentRoom();

        Debug.Log("Game loaded");

    }


    private static void SaveInventory()
    {
        foreach (AS_ObjectScript obj in GL_Inventory.Instance.inventory)
        {
            saveData.inventory.Add(obj.objectName);
            Debug.LogAssertion($"Object Saved: {obj.objectName}");
        }
    }

    private static void LoadInventory()
    {
        List<AS_ObjectScript> newInventory = new List<AS_ObjectScript>();

        if (saveData.inventory.Count > 0)
        {
            foreach (string obj in saveData.inventory)
            {
                if (GL_AssetManager.Instance.Objects.ContainsKey(obj))
                {
                    newInventory.Add(GL_AssetManager.Instance.Objects[obj]);
                }
                else
                {
                    Debug.LogError($"Error: Item '{obj}' not found in asset manager");
                }
            }
            GL_Inventory.Instance.inventory = newInventory;
        }
    }

private static void SaveInteractions(){

}
private static void LoadInteractions(){
    
}


}
