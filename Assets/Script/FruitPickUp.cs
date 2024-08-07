using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickUp : MonoBehaviour
{
    public int amount;

    public GameObject pickupEffect;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FruitPickUpManager.instance.AddFruitAmount(amount);
            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        }
    }
}
