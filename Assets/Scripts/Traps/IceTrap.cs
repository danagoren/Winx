using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : Trap
{
    private Trap trap;
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void ApplyDamage(IDamageable damagable)
    {

    }


    public override void TakeDamage(int howMuch)
    {
        trap.TakeDamage(howMuch);
    }

    public override void Die()
    {
        trap.Die();
    }
}
