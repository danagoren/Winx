using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlora : PlayableCharacter
{
    private Rigidbody2D rb;

    [SerializeField] private NaturePower naturePower;
    [SerializeField] GameObject youDiedScreen;
    [SerializeField] AudioSource audioDeathP;
    [SerializeField] GameObject iceDamage;
    [SerializeField] GameObject naturePowerC;
    [SerializeField] GameObject voidDamage;
    private bool isVoid = false;
    private bool isIced = false;
    [SerializeField] GameObject floraDialoIce;
    [SerializeField] GameObject floraDialoVoid;
    Animator animator;





    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        naturePower = GetComponent<NaturePower>();
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
        if (other.gameObject.CompareTag("IceTrap"))
        {
            TakeDamage(5);
            if (!isIced)
            {
                StartCoroutine(ActivateIceDamage());
            }
        }
        else if (other.gameObject.CompareTag("VoidTrap"))
        {
            TakeDamage(5);
            if (!isVoid)
            {
                StartCoroutine(ActiveVoidDamage());
            }
        }
    }

    IEnumerator ActivateIceDamage()
    {
        isIced = true;
        iceDamage.SetActive(true);
        naturePowerC.SetActive(false);
        floraDialoIce.SetActive(true);

        yield return new WaitForSeconds(10f);

        naturePowerC.SetActive(true);

        iceDamage.SetActive(false);
        isIced = false;

    }

    IEnumerator ActiveVoidDamage()
    {
        isVoid = true;
        voidDamage.SetActive(true);

        naturePowerC.SetActive(false);
        floraDialoVoid.SetActive(true);

        yield return new WaitForSeconds(10f);

        naturePowerC.SetActive(true);

        voidDamage.SetActive(false);
        isVoid = false;

    }



    protected override void Movement()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(movX * speed, movY * speed);
        rb.velocity = movement;
        float moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetBool("isFighting", true);
            transform.localScale = new Vector3(-0.45f, 0.45f, 1f);
            if (moveDirection < 0)
            {
                transform.localScale = new Vector3(0.45f, 0.45f, 1f);
            }
            return;
        }
        else
        {
            animator.SetBool("isFighting", false);
        }
        if (moveDirection > 0)
        {
            animator.SetBool("isFlying", true);
            transform.localScale = new Vector3(0.037f, 0.037f, 1f);
        }
        if (moveDirection < 0)
        {
            animator.SetBool("isFlying", true);
            transform.localScale = new Vector3(-0.037f, 0.037f, 1f);
        }
        if (moveDirection == 0)
        {
            animator.SetBool("isFlying", false);
            transform.localScale = new Vector3(0.037f, 0.037f, 1f);
        }
    }

    protected override void ApplyDamage(IDamageable damagable)
    {
        if (damagable is Collider2D collider2D && collider2D.CompareTag("TreeTrap"))
        {
            damagable.TakeDamage(1);
        }
    }

    protected override void SpecialAbility()
    {
        naturePower.SpecialAbility();
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
