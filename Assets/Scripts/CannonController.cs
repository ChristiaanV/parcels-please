using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private bool isLoaded = false;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject powerIndicator;
    [SerializeField] private CannonSO cannonSo;
    
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private Rigidbody2D projectile;
    [SerializeField] private float maxProjectileVelocity = 10f;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        cannonSo.CannonFire += CannonFire;
    }

    private void OnDisable()
    {
        cannonSo.CannonFire -= CannonFire;
    }

    void Update()
    {
        updateBarrelRotation();
        displayIndicatorConditionaly();
    }

    private void updateBarrelRotation()
    {
        var rot = cannonSo.angleInDegrees;
        barrel.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
    }

    private void displayIndicatorConditionaly()
    {
        powerIndicator.SetActive(isLoaded);
    }

    private void CannonFire()
    {
        if (!isLoaded) return;

        var projectileInstance = Instantiate(projectile, projectileSpawnLocation.transform.position, barrel.transform.rotation);
        var cannonFireVelocity = cannonSo.GetPower() * maxProjectileVelocity;
        projectileInstance.velocity = barrel.transform.up * cannonFireVelocity;
        
        isLoaded = false;
    }
}
