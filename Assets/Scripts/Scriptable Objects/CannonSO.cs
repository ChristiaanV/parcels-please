using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Cannon", menuName = "Game/Cannon")]
public class CannonSO : ScriptableObject
{
    [SerializeField] private float powerSensitivity = 1f, angleSensitivity = 1f;
    
    [SerializeField]
    [Range(0f, 1f)]
    private float power = 0f;
    
    [SerializeField]
    [Range(-90f, 90f)]
    public float angleInDegrees = 90f;
    [SerializeField] private PlayerPrefsSO _playerPrefsSo;
    public event UnityAction CannonFire = delegate {  };
    
    void OnEnable()
    {
        
    }

    public float GetPower()
    {
        return power;
    }

    public void AddPower(float power)
    {
        this.power = math.clamp(this.power + power, 0f, 1f);
    }
    
    public void SetPower(float power)
    {
        this.power = math.clamp(power, 0f, 1f);
    }
    
    public float GetAngleInDegrees()
    {
        return angleInDegrees;
    }

    public void AddAngleInDegrees(float angle)
    {
        this.angleInDegrees = math.clamp(this.angleInDegrees + angle, -90f, 90f);
    }

    private Vector2 GetIndicatorDirection()
    {
        var xDir = - Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
        var yDir = Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);
        return new Vector2(xDir, yDir);
    }

    
    // TODO: Add player controller mouse sensitivity 
    public void MouseInput(Vector2 mouseInput)
    {
        AddPower(mouseInput.y * powerSensitivity);

        AddAngleInDegrees(mouseInput.x * -angleSensitivity * _playerPrefsSo.GetMouseSensitivity());
    }

    public void Fire()
    {
        CannonFire.Invoke();
    }

}
