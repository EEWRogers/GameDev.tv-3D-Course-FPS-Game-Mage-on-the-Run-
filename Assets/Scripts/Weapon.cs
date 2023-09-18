using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] ParticleSystem shootParticles;
    [SerializeField] GameObject hitParticles;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] TextMeshProUGUI ammoText;
    StarterAssetsInputs starterAssetsInputs;
    bool canShoot = true;
    
    void Awake() 
    {
        starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        ammoSlot = FindObjectOfType<Ammo>();
    }

    void OnEnable() 
    {
        canShoot = true;
    }
    
    void Update()
    {
        DisplayAmmo();
        
        if (starterAssetsInputs.fire == true && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    void DisplayAmmo()
    {
        ammoText.text = "Ammo: " + ammoSlot.GetAmmoAmount(ammoType);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            PlayShootVFX();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
            starterAssetsInputs.fire = false;
        }

        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            PlayImpactVFX(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.ReduceHealth(damage);
        }

        else { return; }
    }

    void PlayShootVFX()
    {
        shootParticles.Play();
    }

    void PlayImpactVFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitParticles, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
