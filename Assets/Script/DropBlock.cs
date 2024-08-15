using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    public float distanceToActive;

    public float dropSpeed;
    public float raiseSpeed;

    public float waitToRaise;
    private float waitToRaiseCounter;

    public Transform endPoint;
    private Vector3 startPoint;

    private bool isActive;

    public Animator theAnim;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > PlayerController.instance.transform.position.y && Mathf.Abs(transform.position.x - PlayerController.instance.transform.position.x) < distanceToActive && transform.position == startPoint)
        {
            isActive = true;
            theAnim.SetTrigger("Blink");
        }

        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, dropSpeed * Time.deltaTime);
            if (transform.position == endPoint.position)
            {
                isActive = false;
                waitToRaiseCounter = waitToRaise;
            }
        }
        else 
        {
            if (waitToRaiseCounter > 0)
            {
                waitToRaiseCounter -= Time.deltaTime;

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint, raiseSpeed * Time.deltaTime);
                if (transform.position == endPoint.position)
                {
                    isActive = false;

                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealthController.instance.takeDamage(1);
            isActive = false;
            waitToRaiseCounter = waitToRaise;
            theAnim.SetTrigger("Hit");
        }
    }
}
