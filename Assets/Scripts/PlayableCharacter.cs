using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int HowMuch);
    void Die();
}

public abstract class PlayableCharacter : IDamageable
{
    int speed;
    int currentHP;
    int maxHP;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
    }
    
    void Movement()
    {
    }
    
    void ApplyDamage(IDamageable damagable)
    {

    }
    
    void SpecialAbility()
    {
    }

    public void TakeDamage(int HowMuch)
    {

    }
    public void Die()
    {

    }
}
