using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBloom : PlayableCharacter
{
    private Rigidbody2D rb;

    [SerializeField] private FirePower firePower;
    [SerializeField] GameObject youDiedScreen;
    [SerializeField] AudioSource audioDeathP;
    Animator animator;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        firePower = GetComponent<FirePower>();
        currentHP = 10;
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        Movement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("VoidTrap")) || (other.gameObject.CompareTag("TreeTrap")))
        {
            TakeDamage(5);
        }
    }

    protected override void Movement()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(movX * speed, movY * speed);
        rb.velocity = movement;
        //get the direction
        float moveDirection = Input.GetAxis("Horizontal");
        //change sprite according to direction and state:
        //Debug.Log(moveDirection);
        if (moveDirection > 0)
        {
            animator.SetBool("isFlying", true);
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        }
        if (moveDirection < 0)
        {
            animator.SetBool("isFlying", true);
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        if (moveDirection == 0)
        {
            animator.SetBool("isFlying", false);
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
    }

    protected override void ApplyDamage(IDamageable damagable)
    {
        if (damagable is Collider2D collider2D && collider2D.CompareTag("IceTrap"))
        {
            damagable.TakeDamage(1);
        }
    }

    protected override void SpecialAbility()
    {
        firePower.SpecialAbility();
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
        audioDeathP.Play();
        youDiedScreen.SetActive(true);

        gameObject.SetActive(false);
    }
}
