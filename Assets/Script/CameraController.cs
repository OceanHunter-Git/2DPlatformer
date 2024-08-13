using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Camera theCamera;

    public bool clampCamer;
    public Transform minPos;
    public Transform maxPos;
    private float halfWidth, halfHeight;

    public bool freezeHorizontal, freezeVertical;

    private Vector3 stonePosition;
    // Start is called before the first frame update
    void Start()
    {
        stonePosition = transform.position;

        minPos.SetParent(null);
        maxPos.SetParent(null);

        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * theCamera.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (freezeHorizontal == true)
        {
            transform.position = new Vector3(stonePosition.x, target.position.y, transform.position.z);
        }

        if (freezeVertical == true)
        {
            transform.position = new Vector3( target.position.x, stonePosition.y, transform.position.z);
        }

        if (freezeHorizontal == true && freezeVertical == true)
        {
            transform.position = new Vector3(stonePosition.x, stonePosition.y, transform.position.z);
        }

        if (clampCamer == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.position.x + halfWidth, maxPos.position.x - halfWidth), Mathf.Clamp(transform.position.y, minPos.position.y + halfHeight, maxPos.position.y - halfHeight), transform.position.z);
        }
        ParallaxBackGround.instance.MoveBG();
    }

    private void OnDrawGizmos()
    {
        if (clampCamer == true)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(minPos.position, new Vector3(minPos.position.x, maxPos.position.y, minPos.position.z));
            Gizmos.DrawLine(minPos.position, new Vector3(maxPos.position.x, minPos.position.y, minPos.position.z));

            Gizmos.DrawLine(maxPos.position, new Vector3(minPos.position.x, maxPos.position.y, minPos.position.z));
            Gizmos.DrawLine(maxPos.position, new Vector3(maxPos.position.x, minPos.position.y, minPos.position.z));
        }
    }
}
