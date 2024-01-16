using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap3 : Trap
{
    private int trapHealth = 1;
    [SerializeField] GameObject icyDialo;
    private CameraShake cameraShake;
    [SerializeField] AudioSource audioDeath;
    public ParticleSystem PS;


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
            if (collider2D.CompareTag("Bloom"))
            {
                damagable.TakeDamage(5);
            }
          
        }
    }

    public override void Die()
    {
        audioDeath.Play();
        cameraShake.Shake();
        icyDialo.SetActive(true);
        Invoke("DestroyTrap", 3f);

    }

    private void DestroyTrap()
    {
        icyDialo.SetActive(false);
        Destroy(gameObject);
        PS.Play();
    }
}
