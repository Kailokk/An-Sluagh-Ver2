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
        SaveInteractions();
        SaveCurrentRoom();
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
        GL_GameController.Instance.LoadNewRoom(GL_AssetManager.Instance.Rooms[saveData.currentRoom]);

        Debug.Log("Game loaded");

    }


    private static void SaveInventory()
    {
        foreach (AS_ObjectScript obj in GL_Inventory.Instance.inventory)
        {
            if (!(obj.objectName == ""))
            {
                saveData.inventory.Add(obj.objectName);
                Debug.LogAssertion($"Object Saved: {obj.objectName}");
            }
            else
            {
                Debug.LogError("Object with blank name saved");
            }
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

    private static void SaveInteractions()
    {
       foreach (AS_ObjectScript obj in G_InteractionTracker.Instance.ObjectInteractionList)
        {
            if (!(obj.objectName == ""))
            {
                saveData.objectInteractionList.Add(obj.objectName);
                Debug.LogWarning($"Object interaction Saved: {obj.objectName}");
            }
            else
            {
                Debug.LogError("Object interaction with blank name saved");
            }
        }
         foreach (AS_ObjectScript obj in G_InteractionTracker.Instance.UsedItemList)
        {
            if (!(obj.objectName == ""))
            {
                saveData.usedItemList.Add(obj.objectName);
                Debug.LogWarning($"Used item interaction Saved: {obj.objectName}");
            }
            else
            {
                Debug.LogError("Used item with blank name saved");
            }
        }
    foreach (AS_EntranceScript obj in G_InteractionTracker.Instance.entranceInteractionList)
        {
            if (!(obj.entranceName == ""))
            {
                saveData.EntranceInteractionList.Add(obj.entranceName);
                Debug.LogWarning($"Used item interaction Saved: {obj.entranceName}");
            }
            else
            {
                Debug.LogError("Entrance with blank name saved");
            }
        }
    }

    private static void LoadInteractions()
    {
 List<AS_ObjectScript> newObjectInteractionList = new List<AS_ObjectScript>();
        if (saveData.objectInteractionList.Count > 0)
        {
            foreach (string obj in saveData.objectInteractionList)
            {
                if (GL_AssetManager.Instance.Objects.ContainsKey(obj))
                {
                    newObjectInteractionList.Add(GL_AssetManager.Instance.Objects[obj]);
                }
                else
                {
                    Debug.LogError($"Error: Object '{obj}' not found in asset manager");
                }
            }
            G_InteractionTracker.Instance.ObjectInteractionList = newObjectInteractionList;
        }


        List<AS_ObjectScript> newUsedItemList = new List<AS_ObjectScript>();
        if (saveData.usedItemList.Count > 0)
        {
            foreach (string obj in saveData.usedItemList)
            {
                if (GL_AssetManager.Instance.Objects.ContainsKey(obj))
                {
                    newUsedItemList.Add(GL_AssetManager.Instance.Objects[obj]);
                }
                else
                {
                    Debug.LogError($"Error: Item '{obj}' not found in asset manager");
                }
            }
            G_InteractionTracker.Instance.UsedItemList = newUsedItemList;
        }
        List<AS_EntranceScript> newEntranceInteractionList = new List<AS_EntranceScript>();
        if (saveData.EntranceInteractionList.Count > 0)
        {
            foreach (string obj in saveData.EntranceInteractionList)
            {
                if (GL_AssetManager.Instance.Entrances.ContainsKey(obj))
                {
                    newEntranceInteractionList.Add(GL_AssetManager.Instance.Entrances[obj]);
                }
                else
                {
                    Debug.LogError($"Error: Entrance '{obj}' not found in asset manager");
                }
            }
            G_InteractionTracker.Instance.entranceInteractionList = newEntranceInteractionList;
        }
    }


    private static void SaveCurrentRoom()
    {
        saveData.currentRoom = GL_GameController.Instance.CurrentRoom.roomName;
    }


}
