using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class A_MusicPlayer : MonoBehaviour
{
    private static A_MusicPlayer _instance;
    public static A_MusicPlayer Instance { get { return _instance; } }
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



    private void Start()
    {
        A_MusicEventManager.Instance.onChangeMusic += ChangeMusic;
    }


    private EventReference currentTrack;
    private EventInstance audioEvent;



    private void ChangeMusic(EventReference reference, int playheadLocation)
    {
        if (reference.ToString() == currentTrack.ToString() || reference.IsNull)
        {
            ChangePlayhead(playheadLocation);
            return;
        }
        else if (reference.ToString() != currentTrack.ToString() || !audioEvent.isValid())
        {
            EndTrack();
            StartTrack(reference);
            return;
        }

    }



    private void StartTrack(EventReference reference)
    {
        audioEvent = RuntimeManager.CreateInstance(reference);
        audioEvent.start();
        currentTrack = reference;

    }


    private void EndTrack()
    {
        audioEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    private void ChangePlayhead(int change)
    {
        audioEvent.setParameterByName("Playhead", change);
    }


}
