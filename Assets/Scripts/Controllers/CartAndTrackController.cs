using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartAndTrackController : MonoBehaviour
{

    [SerializeField] private CartSO cartSo;
    [SerializeField] private GameObject cart;
    [SerializeField] private float cartDistanceInPx = 32;
    [SerializeField] Rigidbody2D cartRb;
    [SerializeField] private SpriteRenderer track;
    
    void Start()
    {
    }

    private void Update()
    {
        UpdateTrackPosition();
    }

    void FixedUpdate()
    {
        UpdateCartPosition();
    }

    private void UpdateCartPosition()
    {
        float cartPosAlongTrack = cartSo.getPosition();
        float requiredX = transform.position.x + (cartPosAlongTrack * cartDistanceInPx / 16);
        float requiredY = transform.position.y;
        
        cartRb.MovePosition(new Vector2(requiredX, requiredY));
    }

    private void UpdateTrackPosition()
    {
        track.size = new Vector2((cartDistanceInPx + 36)/ 16 , 0.333f);
    }
}
