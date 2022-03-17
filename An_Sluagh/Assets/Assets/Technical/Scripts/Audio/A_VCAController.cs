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
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        vca.setVolume(mainSlider.value);

        float number;
        vca.getVolume(out number);
        Debug.Log(number);
    }
}
