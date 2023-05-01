using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{
    [SerializeField]    private PlayerPrefsSO _playerPrefsSo;
    void Start()
    {
            _playerPrefsSo.touch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
