using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrap : Trap
{
    private int trapHealth = 1;
    [SerializeField] GameObject darcyDialo;
    private CameraShake cameraShake;



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

            if (collider2D.CompareTag("Flora"))
            {
                damagable.TakeDamage(5);
            }
        }
    }

    public override void Die()
    {
        cameraShake.Shake();
        darcyDialo.SetActive(true);
        Invoke("DestroyTrap", 3f);
    }

    private void DestroyTrap()
    {
        darcyDialo.SetActive(false);
        Destroy(gameObject);
    }

}
