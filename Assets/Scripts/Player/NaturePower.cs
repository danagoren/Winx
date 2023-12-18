using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturePower : MonoBehaviour
{
    [SerializeField] new private ParticleSystem particleSystem;
    private PlayerFlora playerFlora;

    void Awake()
    {
        playerFlora = FindObjectOfType<PlayerFlora>();

        if (particleSystem != null)
        {
            particleSystem.Pause();
        }
    }


    void Update()
    {
        transform.position = playerFlora.transform.position;
        transform.rotation = playerFlora.transform.rotation;

        if (playerFlora.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Return))
        {
            if (particleSystem != null)
            {
                particleSystem.Play();

            }

            ApplyDamageByTag("IceTrap", 10);
        }
    }

    public void TakeDamage(int howMuch)
    {

    }

    public void Die()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("IceTrap"))
        {
            ApplyDamageByTag("IceTrap", 10);
        }
    }

    public void ChangeParticleDirection(Vector2 direction)
    {
        if (particleSystem != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            particleSystem.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ApplyDamageByTag(string tag, int damageAmount)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsWithTag)
        {
            IDamageable damageable = obj.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
            }
        }
    }

    public void SpecialAbility()
    {
    }
}
