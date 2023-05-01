using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    [SerializeField] private PlayerPrefsSO _playerPrefsSo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMouseSensitivity(float s)
    {
        _playerPrefsSo.SetMouseSensitivity(s);
    }

}
