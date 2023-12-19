using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStella : PlayableCharacter
{
    private Rigidbody2D rb;

    [SerializeField] private SunPower sunPower;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        sunPower = GetComponent<SunPower>();
        currentHP = 10;
    }

    protected override void Update()
    {
        base.Update();
        Movement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("IceTrap")) || (other.gameObject.CompareTag("TreeTrap")))
        {
            TakeDamage(10);
        }
    }

    protected override void Movement()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(movX * speed, movY * speed);
        rb.velocity = movement;
    }

    protected override void ApplyDamage(IDamageable damagable)
    {
        if (damagable is Collider2D collider2D && collider2D.CompareTag("VoidTrap"))
        {
            damagable.TakeDamage(10);
        }
    }

    protected override void SpecialAbility()
    {
       sunPower.SpecialAbility();
    }

    public override void TakeDamage(int howMuch)
    {
        currentHP -= howMuch;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }

   }
