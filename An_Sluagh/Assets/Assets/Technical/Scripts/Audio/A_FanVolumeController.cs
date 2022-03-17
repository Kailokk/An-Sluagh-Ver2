using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class A_FanVolumeController : MonoBehaviour
{

    [SerializeField]
    private EventReference snapshot;

    private EventInstance snapshotInstance;

    public void ChangeFanState(bool state)
    {
        if (state == true)
        {
            snapshotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            return;
        }
        snapshotInstance = RuntimeManager.CreateInstance(snapshot);
        snapshotInstance.start();
    }

}
