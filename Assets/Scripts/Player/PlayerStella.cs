using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStella : PlayableCharacter
{
    private PlayableCharacter playableCharacter;
    Rigidbody2D rb;


    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        base.Start();
        playableCharacter = GetComponent<PlayableCharacter>();
    }

    protected override void Update()
    {
        base.Update();
        Movement();
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
    }

    protected override void SpecialAbility()
    {
    }

    public override void TakeDamage(int howMuch)
    {
        playableCharacter.TakeDamage(howMuch);
    }

    public override void Die()
    {
        playableCharacter.Die();
    }
}

