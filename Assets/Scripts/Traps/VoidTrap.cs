using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTrap : Trap
{
    private int trapHealth = 2;
    private CameraShake cameraShake;
    [SerializeField] AudioSource audioDeath;
    [SerializeField] GameObject stormyDialo;


    protected override void Start()
    {
        base.Start();
        cameraShake = Camera.main.GetComponent<CameraShake>();

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
                damagable.TakeDamage(5);
            }
        }
    }

    public override void Die()
    {
        audioDeath.Play();
        cameraShake.Shake();
        stormyDialo.SetActive(true);
        Invoke("DestroyTrap", 3f);
    }

    private void DestroyTrap()
    {
        Destroy(gameObject);
    }
}
