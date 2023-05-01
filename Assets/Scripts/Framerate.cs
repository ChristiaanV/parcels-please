using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    [SerializeField] private int frameRate = 60;
    
    
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }

}