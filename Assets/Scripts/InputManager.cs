using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CannonSO cannonSo;
    [SerializeField] private CartSO cartSo;
    [SerializeField] private ResetManager resetManager;
    
    
    void Update()
    {
        if (cannonSo != null) CannonInput();
        if (cartSo != null) CartInput();
        if (resetManager != null) ResetInput();
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

    private void ResetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetManager.ResetParcel();
        }
    }

    private void CartInput()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        cartSo.MouseInput(_mouseX);
    }
    
}
