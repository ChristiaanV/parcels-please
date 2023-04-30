using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartAndTrackController : MonoBehaviour
{

    [SerializeField] private CartSO cartSo;
    [SerializeField] private GameObject cart;
    [SerializeField] private float cartDistance = 32;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateCartPosition();
    }

    private void UpdateCartPosition()
    {
        float cartPos = cartSo.getPosition();
        cart.transform.position = new Vector3(cartPos * cartDistance / 16, 0, 0);
    }
}
