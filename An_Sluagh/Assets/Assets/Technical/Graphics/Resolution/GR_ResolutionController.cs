using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GR_ResolutionController : MonoBehaviour
{

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private bool isFullScreen = true;

    int currentResolutionIndex;


    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.GetInt("Fullscreen") == 0)
        {
            SetFullScreen(true);
        }
        else
        {
            SetFullScreen(false);
        }

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} X {resolutions[i].height}";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }


    public void SetFullScreen(bool fullScreen)
    {
        isFullScreen = fullScreen;
        Screen.fullScreen = isFullScreen;
        if (fullScreen == true)
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
            return;
        }
        PlayerPrefs.SetInt("Fullscreen", 1);
    }



    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);
        SaveSetting(resolutionIndex);
    }


    private void SaveSetting(int resolutionIndex)
    {
        PlayerPrefs.SetFloat("Resolution", resolutionIndex);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Resolution"))
        {
            SetResolution(PlayerPrefs.GetInt("Resolution"));
        }
    }


}
