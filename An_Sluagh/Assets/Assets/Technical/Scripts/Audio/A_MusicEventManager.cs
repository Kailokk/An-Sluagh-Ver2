using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;


public class A_MusicEventManager : MonoBehaviour
{
    private static A_MusicEventManager _instance;
    public static A_MusicEventManager Instance { get { return _instance; } }
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



    public event Action<EventReference, int> onChangeMusic;
    public void ChangeMusic(EventReference reference, int playheadLocation)
    {
        if (onChangeMusic != null)
        {
            onChangeMusic(reference, playheadLocation);
        }
    }



}
