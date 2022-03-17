using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class A_RoomVerbController : MonoBehaviour
{

    [SerializeField]
    private EventReference snapshot;

    private EventInstance snapshotInstance;

    public void ChangeReverbState(bool state)
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
