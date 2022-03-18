using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class A_RoomVerbController : MonoBehaviour
{

    [SerializeField]
    private EventReference snapshot;

    private EventInstance snapshotInstance;

    private void Start()
    {

        ChangeReverbState(HasStoredValue());

    }


    public void ChangeReverbState(bool state)
    {
        if (state == true)
        {
            snapshotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            StoreValue(state);
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
