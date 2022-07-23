using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class GL_Room_Manager : MonoBehaviour
{

    private static GL_Room_Manager _instance;
    public static GL_Room_Manager Instance { get { return _instance; } set { _instance = value; } }
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



    //writes the current room when called 
    public void ReadRoom(AS_RoomScript currentRoom)
    {

        string output = currentRoom.openingDescription;
        List<string> outputList = new List<string>();

        //checks if the current room has any entrances attached, and adds them/their sub enz
        if (currentRoom.entrances.Any())
        {
            foreach (AS_EntranceScript entrance in currentRoom.entrances)
            {
                if (!G_InteractionTracker.Instance.CheckInteraction(entrance))
                {
                    outputList.Add(entrance.entranceDescription);
                }
            }
        }

        if (currentRoom.objectsInRoom.Any())
        {
            foreach (AS_ObjectScript objectScript in currentRoom.objectsInRoom)
            {
                if (!GL_Inventory.Instance.CheckForItem(objectScript))
                {
                    if (!G_InteractionTracker.Instance.CheckItemUsed(objectScript))
                    {

                        if (G_InteractionTracker.Instance.CheckInteraction(objectScript))
                        {
                            outputList.Add(ParseObject(objectScript));
                        }
                        else
                        {
                            if (!(objectScript.objectDescriptionInRoom == ""))
                            {
                                outputList.Add(objectScript.objectDescriptionInRoom);
                            }
                        }
                    }
                }
            }
        }

        outputList.Add(currentRoom.closingDescription);



        foreach (string text in outputList)
        {
            output = string.Join("\n", output, text);
        }

V_AddTextEntry.Instance.CreateTextEntry("=====================================================================");

        V_AddTextEntry.Instance.CreateTextEntry(output);

    }



    private string ParseObject(AS_ObjectScript objectScript)
    {

        if (objectScript.subObject != null)
        {
            return objectScript.subObject.objectDescriptionInRoom;
        }

        return objectScript.subEntrance.entranceDescription;


    }


    public IEnumerator ReadCinematic(AS_Cinematic_Information cinematic, bool cinematicOrRoom)
    {
        //bool false = room

        V_AddTextEntry.Instance.CreateTextEntry(cinematic.Text);
        V_AddTextEntry.Instance.CreateTextEntry();
        V_AddTextEntry.Instance.CreateTextEntry();
        yield return new WaitForSeconds(cinematic.waitTimeInSeconds);
        if (cinematicOrRoom == false)
        {
            GL_GameController.Instance.LoadNewRoom(cinematic.room);
        }
        else
        {
            GL_GameController.Instance.LoadNextCinematic(cinematic.nextCinematic);
        }
        yield return null;
    }

}