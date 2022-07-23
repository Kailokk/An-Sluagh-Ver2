using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class GL_GameController : MonoBehaviour
{
    private static GL_GameController _instance;
    public static GL_GameController Instance { get { return _instance; } set { _instance = value; } }
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

    [SerializeField]
    private AS_Cinematic_Information startingCinematic;

    //the current room we are in
    [SerializeField]
    private AS_RoomScript currentRoom;
    public AS_RoomScript CurrentRoom
    {
        get { return currentRoom; }
    }

    private void Start()
    {
        DetermineStart();
    }


    //loads a new room
    private void LoadRoom(AS_RoomScript room)
    {
        currentRoom = room;
        if (room.musicInfo != null)
        {
            A_MusicEventManager.Instance.ChangeMusic(room.musicInfo.musicEvent, room.musicInfo.playheadLocation);
        }

        LoadObjects();
        LoadEntrances();

        GL_Room_Manager.Instance.ReadRoom(room);
    }


    private void LoadCinematic(AS_Cinematic_Information cinematic)
    {
        if (cinematic.musicInfo != null)
        {
            A_MusicEventManager.Instance.ChangeMusic(cinematic.musicInfo.musicEvent, cinematic.musicInfo.playheadLocation);
        }
        currentRoom = null;
        objectsInRoom.Clear();
        entrancesInRoom.Clear();
        StartCoroutine(GL_Room_Manager.Instance.ReadCinematic(cinematic, CheckCinematicOrRoom(cinematic)));
    }

    private void LoadObjects()
    {
        objectsInRoom.Clear();
        if (currentRoom.objectsInRoom.Any())
        {
            foreach (AS_ObjectScript objectScript in currentRoom.objectsInRoom)
            {
                if (!G_InteractionTracker.Instance.CheckItemUsed(objectScript))
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
        foreach (AS_ObjectScript obj in currentRoom.objectsInRoom)
        {
            if (G_InteractionTracker.Instance.CheckInteraction(obj))
            {
                if (obj.subEntrance != null)
                {
                    entrancesInRoom.Add(obj.subEntrance);
                }
                if (obj.subObject != null)
                {
                    objectsInRoom.Add(obj.subObject);
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

    public void LoadNextCinematic(AS_Cinematic_Information cinematic)
    {
        LoadCinematic(cinematic);
    }

    public void ReloadItemsAndEntrances()
    {
        LoadObjects();
        LoadEntrances();
    }

    private bool CheckCinematicOrRoom(AS_Cinematic_Information cinematic)
    {
        if (cinematic.room == null && cinematic.nextCinematic != null)
        {
            return true;
        }
        if (cinematic.nextCinematic == null && cinematic.room != null)
        {
            return false;
        }

    //    Debug.LogError("Could not find cinematic or room to load");

       // V_AddTextEntry.Instance.LogError("No valid room or cinematic found");
        return false;
    }


    private void DetermineStart()
    {
        if (startingCinematic != null && startingRoom == null)
        {
            LoadCinematic(startingCinematic);
            return;
        }
        if (startingRoom != null && startingCinematic == null)
        {
            LoadRoom(startingRoom);
            return;
        }

        if (startingCinematic != null && startingRoom != null)
        {
            V_AddTextEntry.Instance.LogError("A starting room, and starting cinematic have been provided");
            return;
        }

        if (startingCinematic == null && startingRoom == null)
        {
            V_AddTextEntry.Instance.LogError("Neither A starting room, nor starting cinematic have been provided");
            return;
        }

    }




}
