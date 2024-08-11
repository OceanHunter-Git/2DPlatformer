using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTraps : MonoBehaviour
{
    public GameObject spikes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spikes.SetActive(true);
        }
        
    }
}
