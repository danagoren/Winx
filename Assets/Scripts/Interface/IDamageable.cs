using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    [SerializeField] public void TakeDamage(int HowMuch);
    [SerializeField] public void Die();
}