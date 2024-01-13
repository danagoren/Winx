using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerStella : PlayableCharacter
{
    private Rigidbody2D rb;
    [SerializeField] private SunPower sunPower;
    [SerializeField] GameObject youDiedScreen;
    [SerializeField] AudioSource audioDeathP;
    [SerializeField] GameObject iceDamage;
    [SerializeField] GameObject poisonDamage;
    [SerializeField] GameObject sunPowerC;
    [SerializeField] GameObject stellaDialoIce;
    [SerializeField] GameObject stellaDialoMash;
    Animator animator;



    private bool isPoisond = false;
    private bool isIced = false;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        sunPower = GetComponent<SunPower>();
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
        else if (other.gameObject.CompareTag("TreeTrap"))
        {
            TakeDamage(5);
            if (!isPoisond)
            {
                StartCoroutine(ActivePoisonDamage());
            }
        }
    }

    IEnumerator ActivateIceDamage()
    {
        isIced = true;
        iceDamage.SetActive(true);

        sunPowerC.SetActive(false);
        stellaDialoIce.SetActive(true);

        yield return new WaitForSeconds(10f);

        sunPowerC.SetActive(true);

        iceDamage.SetActive(false);
        isIced = false;
    }

    IEnumerator ActivePoisonDamage()
    {
        isPoisond = true;
        poisonDamage.SetActive(true);
        sunPowerC.SetActive(false);
        stellaDialoMash.SetActive(true);
        yield return new WaitForSeconds(10f);
        sunPowerC.SetActive(true);
        poisonDamage.SetActive(false);
        isPoisond = false;

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
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            if (moveDirection < 0)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
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
            transform.localScale = new Vector3(-0.22f, 0.22f, 1f);
        }
        if (moveDirection < 0)
        {
            animator.SetBool("isFlying", true);
            transform.localScale = new Vector3(0.22f, 0.22f, 1f);
        }
        if (moveDirection == 0)
        {
            animator.SetBool("isFlying", false);
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
    }

    protected override void ApplyDamage(IDamageable damagable)
    {
        if (damagable is Collider2D collider2D && collider2D.CompareTag("VoidTrap"))
        {
            damagable.TakeDamage(1);
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
        audioDeathP.Play();
        youDiedScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
