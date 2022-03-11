using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Event_Manager : MonoBehaviour
{
    private static A_Event_Manager _instance;
    public static A_Event_Manager Instance { get { return _instance; } }
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






}
