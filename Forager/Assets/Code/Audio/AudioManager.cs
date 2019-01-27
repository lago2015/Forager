using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer mixer;
    public AudioSetting[] audioSettings;
    private enum AudioGroups { Music, SFX };

    void Awake()
    {
        instance = GetComponent<AudioManager>();
    }

    void Start()
    {
        for (int i = 0; i < audioSettings.Length; i++)
        {
            audioSettings[i].Initialize();

        }

    }


    public void SetMusicVolume(float value)
    {
        audioSettings[(int)AudioGroups.Music].SetExposedParam(value);
    }

    public void SetSFXVolume(float value)
    {
        audioSettings[(int)AudioGroups.SFX].SetExposedParam(value);
    }
}

[System.Serializable]
public class AudioSetting
{
    public Slider slider;
    public string exposedParam;

    public void Initialize()
    {
        if (slider)
        {
            slider.value = PlayerPrefs.GetFloat(exposedParam);

        }
    }
    public void SetExposedParam(float value) // 1
    {
        AudioManager.instance.mixer.SetFloat(exposedParam, value); // 3

        PlayerPrefs.SetFloat(exposedParam, value); // 4
    }
}