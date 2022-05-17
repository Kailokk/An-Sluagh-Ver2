using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CRT_Controller_Fade : MonoBehaviour
{
    [SerializeField] EventReference crtOn;
    private FMOD.Studio.EventInstance crtInstance;
    private CanvasGroup canvasGroup;

    void Start()
    {
        GL_Event_Manager.Instance.onTerminalShutdown += onShutDown;
        GL_Event_Manager.Instance.onTerminalBootUp += onBootUp;
        canvasGroup = GetComponent<CanvasGroup>();

    }

    private bool showUI = false;
    private bool hideUI = false;

    private void onBootUp()
    {
        StartCoroutine(booterUpper());
    }


    IEnumerator booterUpper()
    {
        yield return new WaitForSeconds(5);
        crtInstance = FMODUnity.RuntimeManager.CreateInstance(crtOn);
        crtInstance.start();
        yield return new WaitForSeconds(2);
        showUI = true;
    }


    private void onShutDown()
    {
        StartCoroutine(shutterDown());

    }

    IEnumerator shutterDown()
    {
        crtInstance.setParameterByName("Setting", 1);
        crtInstance.release();
        yield return new WaitForSeconds(0.5f);
        canvasGroup.alpha = 1;
    }



    void Update()
    {
        if (showUI)
        {
            if (canvasGroup.alpha <= 1)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    showUI = false;
                    Debug.Log("ShowUI Set To False");
                }
            }
        }

    }
}
