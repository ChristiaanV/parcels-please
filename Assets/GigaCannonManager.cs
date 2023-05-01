using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GigaCannonManager : MonoBehaviour
{
    [SerializeField] private GameObject firePrompt;
    [SerializeField] private CinemachineVirtualCamera gigaCam;
    [SerializeField] private ParticleSystem fireParticles;

    private bool ready = false;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (ready && Input.GetKeyDown(KeyCode.F))
        {
            firePrompt.SetActive(false);
            fireParticles.Play(true);
            ready = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Parcel") return;
        
        col.gameObject.SetActive(false);
        
        firePrompt.SetActive(true);
        gigaCam.Priority = 100;
        
        ready = true;

    }

    private void FireGigaCannon()
    {
        
    }
}
