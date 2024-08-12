using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleController : MonoBehaviour
{
    public bool isActive;

    public GameObject blocker;

    public GameObject boss;
    public float growSpeed;

    public CameraController theCam;

    public Transform camPoint;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        theCam = FindFirstObjectByType<CameraController>();
        boss.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            theCam.transform.position = Vector3.MoveTowards(theCam.transform.position, camPoint.position, moveSpeed * Time.deltaTime);
            if (boss.transform.localScale != Vector3.one)
            {
                boss.transform.localScale = Vector3.MoveTowards(boss.transform.localScale, Vector3.one, growSpeed * Time.deltaTime);
            }
        }       
    }

    public void ActivateBattle()
    {
        isActive = true;
        blocker.SetActive(true);
        theCam.enabled = false;
    }
}
