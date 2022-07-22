using UnityEngine;

public class GL_SaveManager
{

    public static void SaveGame()
    {
        SaveInventory();
        GL_SerialisationManager.Save("save", GL_SaveData.current);
        Debug.Log("Game Saved");
    }

    public static void LoadGame()
    {
        GL_SaveData.current = (GL_SaveData)GL_SerialisationManager.Load(Application.persistentDataPath + "/saves/Save.save");


        LoadInventory();

        //to test if inventory is properly implemented
        GL_GameController.Instance.ReloadCurrentRoom();

        Debug.Log("Game loaded");

    }


    private static void SaveInventory()
    {
        foreach (AS_ObjectScript obj in GL_Inventory.Instance.inventory)
        {

            GL_SaveData.current.inventory.Add(obj.objectName);
        }
    }



    private static void LoadInventory()
    {
        foreach (string obj in GL_SaveData.current.inventory)
        {

        }

    }

}
