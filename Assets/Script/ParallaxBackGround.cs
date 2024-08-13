using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    public static ParallaxBackGround instance;

    private void Awake()
    {
        instance = this;
    }
    private CameraController theCam;

    public Transform sky, treeline;

    [Range(0f,1f)]
    public float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        theCam = FindFirstObjectByType<CameraController>();
    }

    // Update is called once per frame
    public void MoveBG()
    {
        sky.position = new Vector3(theCam.transform.position.x, theCam.transform.position.y, sky.position.z);

        treeline.position = new Vector3(theCam.transform.position.x * parallaxSpeed, theCam.transform.position.y, treeline.position.z);
    }
    public void LateUpdate()
    {
        if (theCam.enabled == false)
        {
            sky.position = new Vector3(theCam.transform.position.x, theCam.transform.position.y, sky.position.z);

            treeline.position = new Vector3(theCam.transform.position.x * parallaxSpeed, theCam.transform.position.y, treeline.position.z);
        }
    }
}
