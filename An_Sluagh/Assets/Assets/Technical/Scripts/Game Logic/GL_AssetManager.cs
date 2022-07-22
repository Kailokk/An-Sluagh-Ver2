using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GL_AssetManager : MonoBehaviour
{
    private static GL_AssetManager _instance;
    public static GL_AssetManager Instance { get { return _instance; } set { _instance = value; } }
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

    [SerializeField]
    private List<AS_ObjectScript> objectList = new List<AS_ObjectScript>();
    [SerializeField]
    private List<AS_EntranceScript> entranceList = new List<AS_EntranceScript>();
    [SerializeField]
    private List<AS_RoomScript> roomList = new List<AS_RoomScript>();


    public Dictionary<string, AS_ObjectScript> Objects = new Dictionary<string, AS_ObjectScript>();
    public Dictionary<string, AS_RoomScript> Rooms = new Dictionary<string, AS_RoomScript>();
    public Dictionary<string, AS_EntranceScript> Entrances = new Dictionary<string, AS_EntranceScript>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (AS_ObjectScript objectScript in objectList)
        {
            Debug.Log($"Object added to asset manager object list: {objectScript.objectName}");
            Objects.Add(objectScript.objectName, objectScript);
        }
        foreach (AS_RoomScript roomScript in roomList)
        {
            Rooms.Add(roomScript.name, roomScript);
        }
        foreach (AS_EntranceScript entranceScript in entranceList)
        {
            Entrances.Add(entranceScript.name, entranceScript);
        }
    }


}
