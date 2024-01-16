using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamageable
{
    [SerializeField] List<PlayableCharacter> whatIDamage;
 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected abstract void ApplyDamage(IDamageable damagable);

    public abstract void TakeDamage(int HowMuch);


    public abstract void Die();
}
