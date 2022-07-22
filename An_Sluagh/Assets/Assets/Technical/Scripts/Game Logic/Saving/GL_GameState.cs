using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GL_GameState
{
    private static GL_GameState _current;
    public static GL_GameState current
    {
        get
        {
            if (_current == null)
            {
                _current = new GL_GameState();
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










}