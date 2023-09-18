using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    StarterAssetsInputs starterAssetsInputs;
    
    void Start()
    {
        starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        SetWeaponActive();
    }

    void Update() 
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollInput();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProcessKeyInput()
    {
        if (starterAssetsInputs.weaponSelection > 0)
        {
            currentWeapon = (Mathf.RoundToInt(starterAssetsInputs.weaponSelection - 1));
        }
    }

    void ProcessScrollInput()
    {
        if (starterAssetsInputs.weaponScroll.y > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if (starterAssetsInputs.weaponScroll.y < 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(weaponIndex == currentWeapon); // if weaponIndex equals the current weapon, set it as active
            weaponIndex++;
        }
    }
}
