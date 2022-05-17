using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class A_TerminalManager_Demo : MonoBehaviour
{

    private static A_TerminalManager_Demo _instance;
    public static A_TerminalManager_Demo Instance { get { return _instance; } }
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
    EventReference ambience;
   

    public bool showUI = false;

    private FMOD.Studio.EventInstance ambienceInstance;


    private void Start()
    {
        GL_Event_Manager.Instance.onTerminalShutdown += onShutDown;
        GL_Event_Manager.Instance.onTerminalBootUp += onBootUp;
    }

    private void onBootUp()
    {
        showUI = true;
        PlayBackgroundAmbience();

    }

    private void onShutDown()
    {
        ambienceInstance.setParameterByName("Setting", 1);
        showUI = false;
       
        //anim.play
    }


    private void PlayBackgroundAmbience()
    {
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(ambience);
        ambienceInstance.start();
        
    }


    [SerializeField]
    EventReference actionConfirmation;
    public void PlayActionConfirmation()
    {
        FMODUnity.RuntimeManager.PlayOneShot(actionConfirmation);
    }



    [SerializeField]
    EventReference TextTypingSound;
    private FMOD.Studio.EventInstance TextTyping;
    public void PlayTextTyping()
    {

        FMODUnity.RuntimeManager.PlayOneShot(TextTypingSound);


        /* 
                TextTyping = FMODUnity.RuntimeManager.CreateInstance(TextTypingSound);
                TextTyping.start();
         */
    }

    /*     public void StopTextTyping()
        {
            TextTyping.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

     */
}
