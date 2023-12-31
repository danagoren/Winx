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
    [SerializeField] GameObject poisenDamage;
    [SerializeField] GameObject naturePowerC;
    private bool isIced = false;
    private bool isPoisend = false;



    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        naturePower = GetComponent<NaturePower>();
        currentHP = 10;
    }

    protected override void Update()
    {
        base.Update();
        Movement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IceTrap") || other.gameObject.CompareTag("VoidTrap"))
        {
            TakeDamage(5);
            if (!isIced)
            {
                StartCoroutine(ActivateIceDamage());
            }
           if(!isPoisend) 
            {
               StartCoroutine(ActivePoisenDamage());

            }
        }
    }

    IEnumerator ActivateIceDamage()
    {
        isIced = true;
        iceDamage.SetActive(true);

        naturePowerC.SetActive(false);

        yield return new WaitForSeconds(30f);

        naturePowerC.SetActive(true);

        iceDamage.SetActive(false);
        isIced = false;
    }

    IEnumerator ActivePoisenDamage() 
    {
        isPoisend = true;
        poisenDamage.SetActive(true);
        naturePowerC.SetActive(false);
        yield return new WaitForSeconds(30f);
        naturePowerC.SetActive(true);
        poisenDamage.SetActive(false) ;
        isPoisend= false;   


    
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
