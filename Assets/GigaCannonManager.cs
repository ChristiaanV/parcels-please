using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GigaCannonManager : MonoBehaviour
{
    [SerializeField] private GameObject firePrompt;
    [SerializeField] private CinemachineVirtualCamera gigaCam;
    [SerializeField] private ParticleSystem fireParticles;


    private CinemachineImpulseSource _impulseSource;
    private bool ready = false;
    
    void Start()
    {
        _impulseSource = gameObject.GetComponent<CinemachineImpulseSource>();
    }


    void Update()
    {
        if (ready && Input.GetKeyDown(KeyCode.F))
        {
            FireGigaCannon();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Parcel") return;
        
        col.gameObject.SetActive(false);
        
        firePrompt.SetActive(true);
        gigaCam.Priority = 100;

        SoundManager.Instance.Play(SoundManager.Instance.LoadGigaSFX);
        
        ready = true;

    }

    private void FireGigaCannon()
    {
        firePrompt.SetActive(false);
        SoundManager.Instance.Play(SoundManager.Instance.FireGigaSFX);
        fireParticles.Play(true);
        ready = false;
        _impulseSource.GenerateImpulse(4f);
        StartCoroutine(WaitThenGoToMainMenu());
    }
    
    
    IEnumerator WaitThenGoToMainMenu()
    {
        yield return new WaitForSeconds(6);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main Menu");
    }
}
