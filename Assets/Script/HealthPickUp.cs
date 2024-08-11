using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public ParticleSystem healthPS;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.addHealth(1);
                Instantiate(healthPS, transform.position, transform.rotation);
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(10);
            }
        }
    }
}
