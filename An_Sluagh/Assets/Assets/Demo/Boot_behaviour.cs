using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot_behaviour : MonoBehaviour
{

    private bool isOn = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Home))
        {
            if (isOn == false)
            {
                GL_Event_Manager.Instance.TerminalBootUp();
                isOn = true;
            }
            else
            {
                if (isOn == true)
                {
                    GL_Event_Manager.Instance.TerminalShutdown();
                    isOn = false;
                }
            }
        }
    }
}
