using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSetting : MonoBehaviour {

    public Slider audioSlider, brightnessSlider;
    public Dropdown resoultiondDropdown, qualityDropdown;
    public Toggle fullscreenToggle;

    public AudioSource audioSource;

    public Resolution[] resolutions;

    private SettingManager setting;


    private void OnEnable()
    {
        setting = new SettingManager();

        audioSlider.onValueChanged.AddListener
            (
            delegate 
            {
                OnAudioChange();
            }
            );

        brightnessSlider.onValueChanged.AddListener
            (
            delegate
            {
                OnBrightnessChange();
            }
            );

        resoultiondDropdown.onValueChanged.AddListener
            (
            delegate
            {
                OnResoultionChange();
            }
            );

        resolutions = Screen.resolutions;

        qualityDropdown.onValueChanged.AddListener
            (
            delegate
            {
                OnQualityChange();
            }
            );

        fullscreenToggle.onValueChanged.AddListener
            (
            delegate
            {
                OnFullScreenChange();
            }
            );
    }

    public void OnAudioChange()
    {
        audioSource.volume = setting.Audio = audioSlider.value;
    }

    public void OnBrightnessChange()
    {
        
    }

    public void OnResoultionChange()
    {

    }

    public void OnQualityChange()
    {
        QualitySettings.antiAliasing = setting.quality =(int)Mathf.Pow(2f, qualityDropdown.value);
    }

    public void OnFullScreenChange()
    {
        setting.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void SaveSetting()
    {

    }

    public void LoadSetting()
    {

    }
}
