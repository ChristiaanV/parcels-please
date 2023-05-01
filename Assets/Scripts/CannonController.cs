using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private bool isLoaded = false;
    [SerializeField] private bool checkpoint = true;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject powerIndicator;
    [SerializeField] private CannonSO cannonSo;
    
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private Rigidbody2D projectile;
    [SerializeField] private float minProjectileVelocity = 3f;
    [SerializeField] private float maxProjectileVelocity = 10f;

    [SerializeField]
    private CinemachineVirtualCamera cmCam;


    void Start()
    {
        // cmCam = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        if (isLoaded)
        {
            LoadProjectile();
        }
        else
        {
            UnloadProjectile();
        }

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
        var cannonFireVelocity = minProjectileVelocity + (maxProjectileVelocity - minProjectileVelocity) * cannonSo.GetPower();
        projectileInstance.velocity = barrel.transform.up * cannonFireVelocity;
        
        cannonSo.SetPower(0.75f);
        UnloadProjectile();
    }

    public bool GetIsLoaded()
    {
        return isLoaded;
    }

    public void LoadProjectile()
    {
        isLoaded = true;
        //cmCam.enabled = true;
        cmCam.Priority = 10;
        if (checkpoint)
        {
            makeCannonCheckpoint();           
        }
        GameObject.FindObjectOfType<ResetManager>().DestroyAllParcels();

    }

    public void UnloadProjectile()
    {
        isLoaded = false;
        cmCam.Priority = 2;
        //cmCam.enabled = false;
    }

    public void makeCannonCheckpoint()
    {
        GameObject.FindObjectOfType<ResetManager>().SetCheckpointCannon(this);
    }
}
