using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Cinematic")]
public class AS_Cinematic_Information : ScriptableObject
{

    [TextArea]
    public string Text;
    public float waitTimeInSeconds = 1;

    public AS_RoomScript room;
    public AS_Cinematic_Information nextCinematic;




}
