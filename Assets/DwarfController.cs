using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    [SerializeField] private GameObject speechObject;
    private bool speechTriggered = false;
    [SerializeField] private float speechDurationInSeconds = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("Collided");
        if (col.gameObject.tag != "Parcel") return;
        if (speechTriggered) return;
        Debug.Log("Start speech");
        speechTriggered = true;
        speechObject.SetActive(true);
        StartCoroutine(HideSpeech());

    }

    IEnumerator HideSpeech()
    {
        yield return new WaitForSeconds(speechDurationInSeconds);
        speechObject.SetActive(false);
    }
}