using UnityEngine;

public class GL_SaveManager : MonoBehaviour
{

    public void SaveGame()
    {
        GL_SaveData.current.room_Manager = GL_Room_Manager.Instance;


        GL_SerialisationManager.Save("save", GL_SaveData.current);
    }

    public void LoadGame()
    {

        GL_SaveData.current = (GL_SaveData)GL_SerialisationManager.Load(Application.persistentDataPath + "/saves/Save.save");


        GL_Room_Manager.Instance = GL_SaveData.current.room_Manager;
    }




    private void LoadRoomManager()
    {


    }

}
