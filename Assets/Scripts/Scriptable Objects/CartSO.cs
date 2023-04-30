using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Cart", menuName = "Game/Cart")]
public class CartSO : ScriptableObject
{

    [SerializeField] private float cartSensitivity = 1f;

    [SerializeField] 
    [Range(0, 1)] 
    private float cartPosition = 0f;


    public void addPosition(float pos)
    {
        cartPosition = Mathf.Clamp(cartPosition + pos, 0f, 1f);
    }

    public float getPosition()
    {
        return cartPosition;
    }

    public void MouseInput(float x)
    {
        addPosition(x * cartSensitivity);
    }
    
}
