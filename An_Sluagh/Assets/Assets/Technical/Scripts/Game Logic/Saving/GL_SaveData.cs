using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GL_SaveData
{
    private static GL_SaveData _current;

    public static GL_SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new GL_SaveData();
            }
            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }


    public GL_Room_Manager room_Manager;













}
