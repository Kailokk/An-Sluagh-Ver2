using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class A_FanVolumeController : MonoBehaviour
{

    [SerializeField]
    private EventReference snapshot;

    private EventInstance snapshotInstance;

    private void Start()
    {

        ChangeFanState(HasStoredValue());

    }

    public void ChangeFanState(bool state)
    {
        if (state == true)
        {
            snapshotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            return;
        }
        snapshotInstance = RuntimeManager.CreateInstance(snapshot);
        snapshotInstance.start();
        StoreValue(state);
    }




    private bool HasStoredValue()
    {
        if (PlayerPrefs.HasKey("ReverbState"))
        {
            if (PlayerPrefs.GetInt("reverbState") == 1)
            {
                return true;
            }
        }
        return false;
    }

    private void StoreValue(bool reverbState)
    {
        if (reverbState == true)
        {
            PlayerPrefs.SetInt("ReverbState", 1);
            return;
        }
        PlayerPrefs.SetInt("ReverbState", 0);
    }




}
