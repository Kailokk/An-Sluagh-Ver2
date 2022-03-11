using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Terminal/Entrance")]
public class AS_EntranceScript : ScriptableObject
{
    /* An object to hold entrances to other room, 
    this is to allow the flexibility describing room transitions*/

    //The keywords used to find this entrance in the list
    public string[] keywords;

    //The room that is transitioned to
    public AS_RoomScript room;

    //The description of the entrance in the given room
    [TextArea]
    public string entranceDescription;

    //The List of potential interactions
    public AS_InteractionScript[] interactions;

    //The list of pre-requisite objects that might be needed to access the entrance
    public AS_ObjectScript[] interactionObjects;

}
