using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    float defaultLightIntensity;
    float defaultLightAngle;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        defaultLightIntensity = myLight.intensity;
        defaultLightAngle = myLight.spotAngle;
    }

    
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle > minimumAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreLight()
    {
        myLight.intensity = defaultLightIntensity;
        myLight.spotAngle = defaultLightAngle;
    }
}
