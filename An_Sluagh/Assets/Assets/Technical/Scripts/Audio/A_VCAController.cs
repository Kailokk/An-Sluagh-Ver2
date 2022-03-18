using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class A_VCAController : MonoBehaviour
{
    public Slider mainSlider;
    public string VCAPath;
    private VCA vca;

    private float volume;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        vca = RuntimeManager.GetVCA(VCAPath);
        LoadSettings();
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        vca.setVolume(mainSlider.value);
        volume = mainSlider.value;
    }

    private void OnDisable()
    {
        SaveSetting();
    }

    private void SaveSetting()
    {
        PlayerPrefs.SetFloat(VCAPath, volume);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(VCAPath)){
            mainSlider.value = PlayerPrefs.GetFloat(VCAPath);
        ValueChangeCheck();}
    }


}
