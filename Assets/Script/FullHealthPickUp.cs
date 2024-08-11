using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthPickUp : MonoBehaviour
{
    public ParticleSystem healthPS;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.addHealth(PlayerHealthController.instance.maxHealth);
                Instantiate(healthPS, transform.position, transform.rotation);
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(10);
            }
        }
    }
}
