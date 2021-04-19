using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{
    public Light2D AimLight;
    
    // Start is called before the first frame update
    void Start()
    {
        AimLight = GetComponentInChildren<Light2D>();

        if (AimLight)
        {
           // Debug.Log("AimLight found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            AimLight.enabled = true;
            Debug.Log("Intensity of light is: " + AimLight.intensity );
        }
    }
}
