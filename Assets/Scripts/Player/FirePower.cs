using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : MonoBehaviour
{
    [SerializeField] new private ParticleSystem particleSystem;
    private PlayerBloom playerBloom;
    private CameraShake cameraShake;



    void Awake()
    {
        playerBloom = FindObjectOfType<PlayerBloom>();

        if (particleSystem != null)
        {
            particleSystem.Pause();
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    void Update()
    {
        transform.position = playerBloom.transform.position;
        transform.rotation = playerBloom.transform.rotation;

        if (playerBloom.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Return))
        {
            ActivateAbility();
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
        if (other.CompareTag("IceTrap"))
        {
            ApplyDamageByTag("IceTrap", 1);
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
