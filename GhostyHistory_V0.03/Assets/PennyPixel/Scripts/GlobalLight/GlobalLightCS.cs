using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightCS : MonoBehaviour
{
    public Light2D GlobalLight;

    private bool lightStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        GlobalLight = GetComponent<Light2D>();
        
        Debug.Log("GlobalLight found!");

        GlobalLight.intensity = 0f;

        lightStatus = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (lightStatus == false)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                       GlobalLight.intensity = 1.31f;
           
                       lightStatus = true;
                       
                       Debug.Log("LightChange to" + lightStatus);
            } 
        }
        if (lightStatus == true)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                GlobalLight.intensity = 0f;
           
                lightStatus = false;
                       
                Debug.Log("LightChange to" + lightStatus);
            } 
        }
        
        
     
    }
}
