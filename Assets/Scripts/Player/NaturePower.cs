using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturePower : MonoBehaviour
{
    [SerializeField] new private ParticleSystem particleSystem;
    private PlayerFlora playerFlora;
    private CameraShake cameraShake;

    void Awake()
    {
        playerFlora = FindObjectOfType<PlayerFlora>();

        if (particleSystem != null)
        {
            particleSystem.Pause();
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    void Update()
    {
        if (playerFlora != null)
        {
            transform.position = playerFlora.transform.position;
            transform.rotation = playerFlora.transform.rotation;

            if (playerFlora.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Return))
            {
                ActivateAbility();
            }
        }
    }

    void ActivateAbility()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
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
        if (other.CompareTag("TreeTrap"))
        {
            ApplyDamageByTag("TreeTrap", 1);
            cameraShake.Shake();
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
