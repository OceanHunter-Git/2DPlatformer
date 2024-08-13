using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed;

    private Vector3 direction;

    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        direction = (PlayerController.instance.transform.position - transform.position).normalized;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthController.instance.takeDamage(1);
            Destroy(gameObject);
        }
    }
}
