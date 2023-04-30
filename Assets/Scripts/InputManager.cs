using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CannonSO cannonSo;
    
    void Update()
    {
        if (cannonSo != null) CannonInput();
    }

    private void CannonInput()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        float _mouseY = Input.GetAxis("Mouse ScrollWheel");
        cannonSo.MouseInput(new Vector2(_mouseX, _mouseY));

        if (Input.GetMouseButtonDown(0))
        {
            cannonSo.Fire();
        }
    }
    
}
