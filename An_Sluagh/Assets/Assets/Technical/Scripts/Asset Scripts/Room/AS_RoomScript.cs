using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Room")]
public class AS_RoomScript : ScriptableObject
{

    public string roomName;
    //The description that is read when you enter the room
    [TextArea]
    public string openingDescription;

    //The description read when you enter a room, after entrances/objects in the room are listed
    [TextArea]
    public string closingDescription;

    //The list of entrances to other rooms that are read after the opening description
    public AS_EntranceScript[] entrances;

    //the list of objects in the room that are read after the entrances
    public AS_ObjectScript[] objectsInRoom;


    public AS_MusicInformation musicInfo;



}
