using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    private void Awake()
    {
        instance = this;
    }

    public float destroyWaitTime;
    public float destroyWaitTimeCounter;
    public Animator theAnim;

    public bool isDefeated;

    public bool isFriend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeated)
        {
            destroyWaitTimeCounter -= Time.deltaTime;
            if (destroyWaitTimeCounter < 0)
            {
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(5);
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")  && isFriend == false)
        {
            PlayerHealthController.instance.takeDamage(1);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isFriend == false)
        {
            destroyWaitTimeCounter = destroyWaitTime;
            isDefeated = true;
            theAnim.SetTrigger("isDefeated");
            AudioManager.instance.PlaySFX(6);
            PlayerController.instance.Jump();
        }    
    }
}
