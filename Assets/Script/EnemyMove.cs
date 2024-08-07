using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] patrolPoints;

    public int currentPoint;

    public float moveSpeed;

    public float pointWaitTime;

    public float pointWaitTimeCounter;

    public Animator theAnim;
    // Start is called before the first frame update
    void Start()
    {
        theAnim.SetBool("isMoving", true);
        foreach (Transform t in patrolPoints)
        {
            t.SetParent(null);
        }
        pointWaitTimeCounter = pointWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyController.instance.isDefeated == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

            if (transform.position == patrolPoints[currentPoint].position)
            {
                theAnim.SetBool("isMoving", false);
                pointWaitTimeCounter -= Time.deltaTime;
                if (pointWaitTimeCounter < 0)
                {
                    currentPoint++;
                    pointWaitTimeCounter = pointWaitTime;
                    theAnim.SetBool("isMoving", true);
                    if (currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }

                    if (transform.position.x < patrolPoints[currentPoint].position.x)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
            }
        }
    }
}
