using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamageable
{
    [SerializeField] LayerMask whatIDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(IDamageable damagable)
    {

    }

    public void TakeDamage(int HowMuch)
    {

    }
    
    public void Die()
    {

    }
}
