using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTrap : Trap
{
    private int trapHealth = 100;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void TakeDamage(int howMuch)
    {
        trapHealth -= howMuch;

        if (trapHealth <= 0)
        {
            Die();
        }
    }
    protected override void ApplyDamage(IDamageable damagable)
    {
        Collider2D collider2D = damagable as Collider2D;
        if (collider2D != null)
        {
           
            if (collider2D.CompareTag("Stella"))
            {
                damagable.TakeDamage(10);
            }
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
