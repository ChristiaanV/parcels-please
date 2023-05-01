using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class UIInputManager : MonoBehaviour
{
    [SerializeField] private PlayerPrefsSO _playerPrefsSo;


    [SerializeField] private Slider mouse, music, sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse.value = _playerPrefsSo.GetMouseSensitivity();
        music.value = _playerPrefsSo.GetMusicVolume();
        sfx.value = _playerPrefsSo.GetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateMouseSensitivity(float s)
    {
        _playerPrefsSo.SetMouseSensitivity(s);
    }
    
    public void UpdateMusic(float s)
    {
        _playerPrefsSo.SetMusicVolume(s);
    }
    
    public void UpdateSFX(float s)
    {
        _playerPrefsSo.SetSFXVolume(s);
    }

}
