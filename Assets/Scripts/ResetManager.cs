using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{

    private CannonController checkPointCannon;
    
    void Start()
    {
        DestroyAllParcels();
    }

    void Update()
    {
        
    }

    public void SetCheckpointCannon(CannonController checkpointCannon)
    {
        this.checkPointCannon = checkpointCannon;
    }

    public void ResetParcel()
    {
        DestroyAllParcels();
        ResetAllCannons();
        if (checkPointCannon == null) return;
        checkPointCannon.LoadProjectile();
    }

    private void DestroyAllParcels()
    {
        
        var parcels = GameObject.FindGameObjectsWithTag("Parcel");

        foreach (GameObject parcel in parcels)
        {
            Destroy(parcel);
        }
    }

    private void ResetAllCannons()
    {
        var cannons = GameObject.FindGameObjectsWithTag("Cannon");

        foreach (GameObject cannon in cannons)
        {
            cannon.GetComponent<CannonController>().UnloadProjectile();
        }
    }
}
