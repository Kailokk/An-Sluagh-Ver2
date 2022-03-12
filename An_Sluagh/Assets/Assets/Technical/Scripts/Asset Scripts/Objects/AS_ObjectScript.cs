using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Object")]
public class AS_ObjectScript : ScriptableObject
{

    public string objectName;
    //The list of keywords used to identify the object
    public string[] keywords;

    //The description of the object as it appears in the room
    [TextArea]
    public string objectDescriptionInRoom;

    //The list of possible interactions with the object
    public AS_InteractionScript[] Interactions;

    //The object that may be revealed if the palyer interacts with the main object
    public AS_ObjectScript subObject;

    //The entrance that may be revealed if the palyer interacts with the main object
    public AS_EntranceScript subEntrance;

}
