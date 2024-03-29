using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPower : MonoBehaviour
{
    [SerializeField]  private ParticleSystem particleSystem;
    private PlayerStella playerStella;
    private CameraShake cameraShake;


    void Awake()
    {
        playerStella = FindObjectOfType<PlayerStella>();

        if (particleSystem != null)
        {
            particleSystem.Pause();
            cameraShake = Camera.main.GetComponent<CameraShake>();

        }

    }

    void Update()
    {
        if (playerStella != null)
        {
            transform.position = playerStella.transform.position;
            transform.rotation = playerStella.transform.rotation;

            if (playerStella.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Return))
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
        if (other.CompareTag("VoidTrap") || other.CompareTag("VoidTrap2") || other.CompareTag("VoidTrap3") || other.CompareTag("VoidTrap4") || other.CompareTag("VoidTrap5"))
        {
            ApplyDamageByTag(other.tag, 1);
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
