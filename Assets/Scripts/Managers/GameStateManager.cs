using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public InputManager InputManager;
    public GameObject settingsMenu;

    private bool InGameState = true;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InGameState = !InGameState;
            
            if (InGameState)
            {
                StartGameState();
            }
            else
            {
                StartSettingsState();
            }
        }
    }

    public void StartGameState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        settingsMenu.SetActive(false);
        InputManager.InGameState = true;
    }

    public void StartSettingsState()
    {
        Cursor.lockState = CursorLockMode.Confined;
        settingsMenu.SetActive(true);
        InputManager.InGameState = false;
    }
}
