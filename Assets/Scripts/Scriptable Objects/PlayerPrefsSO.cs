using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Prefs", menuName = "Game/Player Prefs")]
public class PlayerPrefsSO : ScriptableObject
{
    [SerializeField] [Range(0.01f, 10f)] private float mouseSensitivity;
    [SerializeField] [Range(0f, 1f)] private float musicVolume;
    [SerializeField] [Range(0f, 1f)] private float sfxVolume;

    public void touch()
    {
    }

    private void OnEnable()
    {
        if (UnityEngine.PlayerPrefs.GetFloat("MouseSensitivity") == 0)
        {
            SetMouseSensitivity(3f);
            SetMusicVolume(0.5f);
            SetSFXVolume(0.5f);
        }
        else
        {
            mouseSensitivity = UnityEngine.PlayerPrefs.GetFloat("MouseSensitivity");
            musicVolume = UnityEngine.PlayerPrefs.GetFloat("musicVolume");
            sfxVolume = UnityEngine.PlayerPrefs.GetFloat("sfxVolume");
        }

    }

    public float GetMouseSensitivity()
    {
        return mouseSensitivity;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void SetMouseSensitivity(float Sensitivity)
    {
        mouseSensitivity = Mathf.Clamp(Sensitivity, 0.01f, 10f);
        UnityEngine.PlayerPrefs.SetFloat("MouseSensitivity", mouseSensitivity);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp(volume, 0f, 1f);
        UnityEngine.PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp(volume, 0f, 1f);
        UnityEngine.PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
}
