using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    DeathHandler deathHandler;
    DisplayDamage displayDamage;

    void Awake() 
    {
    deathHandler = GetComponent<DeathHandler>();
    displayDamage = GetComponent<DisplayDamage>();
    }

    public void TakeDamage(float damage)
    {
        displayDamage.DisplayDamageIndicator();
        hitPoints -= damage;
        
        if (hitPoints <= 0)
        {
            displayDamage.DisplayDamageIndicator();
            deathHandler.HandleDeath();
        }
    }
}
