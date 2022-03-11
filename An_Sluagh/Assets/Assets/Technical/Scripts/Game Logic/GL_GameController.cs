using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GL_GameController : MonoBehaviour
{
    private static GL_GameController _instance;
    public static GL_GameController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public List<AS_ObjectScript> objectsInRoom = new List<AS_ObjectScript>();
    public List<AS_EntranceScript> entrancesInRoom = new List<AS_EntranceScript>();

    List<string> actionWordsInRoom = new List<string>();

    //the room that the game starts from
    [SerializeField]
    private AS_RoomScript startingRoom;

    //the current room we are in
    private AS_RoomScript currentRoom;




    private void Start()
    {

        LoadRoom(startingRoom);

    }



    //loads a new room
    private void LoadRoom(AS_RoomScript room)
    {
        currentRoom = room;


        LoadObjects();
        LoadEntrances();

        GL_Room_Manager.Instance.ReadRoom(room);
    }


    private void LoadObjects()
    {
        objectsInRoom.Clear();
        if (currentRoom.objectsInRoom.Any())
        {
            foreach (AS_ObjectScript objectScript in currentRoom.objectsInRoom)
            {
                if (!GL_Inventory.Instance.CheckForItem(objectScript))
                {
                    if (G_InteractionTracker.Instance.CheckInteraction(objectScript))
                    {
                        if (objectScript.subObject != null)
                        {
                            objectsInRoom.Add(objectScript.subObject);
                        }
                        else
                        {
                            entrancesInRoom.Add(objectScript.subEntrance);
                        }
                    }
                    else { objectsInRoom.Add(objectScript); }
                }


            }
        }

    }

    private void LoadEntrances()
    {
        entrancesInRoom.Clear();
        if (currentRoom.entrances.Any())
        {
            foreach (AS_EntranceScript entrance in currentRoom.entrances)
            {
                if (!G_InteractionTracker.Instance.CheckInteraction(entrance))
                {
                    entrancesInRoom.Add(entrance);
                    foreach (AS_InteractionScript interaction in entrance.interactions)
                    {
                        foreach (string actionWord in interaction.actionWords)
                            actionWordsInRoom.Add(actionWord);
                    }
                }
            }
        }

    }


    public void ReloadCurrentRoom()
    {
        LoadRoom(currentRoom);
    }

    public void LoadNewRoom(AS_RoomScript room)
    {
        LoadRoom(room);
    }

    public void ReloadItemsAndEntrances()
    {
        LoadObjects();
        LoadEntrances();
    }

}
