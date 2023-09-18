using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    public bool IsDead { get { return isDead; } }

    Animator animator;

    void Awake() 
    {
        animator = GetComponent<Animator>();
    }
    public void ReduceHealth(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");

        if (hitPoints <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) { return; }
        
        animator.SetTrigger("die");
        isDead = true;
    }
}
