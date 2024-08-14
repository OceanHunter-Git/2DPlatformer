using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform platform;
    public Transform[] points;
    public int currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, speed * Time.deltaTime);

        if (platform.position == points[currentPoint].position)
        {
            currentPoint++;
            if (currentPoint == points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
