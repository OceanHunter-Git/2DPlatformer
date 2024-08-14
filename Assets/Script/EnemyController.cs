using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    private void Awake()
    {
        instance = this;
    }

    public float destroyWaitTime;
    private float destroyWaitTimeCounter;
    public Animator theAnim;

    public bool isDefeated;

    public bool isFriend;

    public bool shouldChasePlayer;

    public bool isChasing;
    public float distanceToChasePlayer;
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
        else
        {
            if (shouldChasePlayer == true)
            {
                if (isChasing == false)
                {
                    if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < distanceToChasePlayer) 
                    {
                        isChasing = true;
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToChasePlayer)
                    {
                        isChasing = false;
                    }
                }
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
