using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera weaponCamera;
    [SerializeField] CinemachineVirtualCamera playerCamera;

    [SerializeField] float defaultFOV = 90f;
    [SerializeField] float zoomedFOV = 40f;

    [SerializeField] float defaultSensitivity;
    [SerializeField] float zoomedSensitivity = 0.25f;

    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;

    void Awake() 
    {
        starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        firstPersonController = FindObjectOfType<FirstPersonController>();
        defaultSensitivity = firstPersonController.RotationSpeed;
    }

    void OnDisable() 
    {
        ToggleZoom(defaultFOV, defaultSensitivity);
    }

    void Update() 
    {
        if (starterAssetsInputs == null) { return; }

        if (starterAssetsInputs.zoom == true)
        {
            ToggleZoom(zoomedFOV, zoomedSensitivity);
        }
        else
        {
            ToggleZoom(defaultFOV, defaultSensitivity);
        }
    }

    void ToggleZoom(float zoomValue, float sensitivityValue)
    {
        weaponCamera.fieldOfView = zoomValue;
        playerCamera.m_Lens.FieldOfView = zoomValue;
        firstPersonController.RotationSpeed = sensitivityValue;
    }
}
