using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableCharacter : MonoBehaviour, IDamageable
{
    [SerializeField] protected int speed;
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }

    protected abstract void Movement();

    protected abstract void ApplyDamage(IDamageable damagable);

    protected abstract void SpecialAbility();

    public abstract void TakeDamage(int howMuch);

    public abstract void Die();
}
