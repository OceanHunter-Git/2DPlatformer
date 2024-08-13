using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleController : MonoBehaviour
{
    public bool isActive;

    public GameObject blocker;

    public GameObject boss;
    public float bossgrowSpeed;
    public Animator bossAnim;
    private bool isWeak;
    public GameObject bossDeathEffect;

    public float bossMoveSpeed;
    public Transform[] movePoint;
    private int currentMovePoint;

    public GameObject projectileLauncher;
    public float launchergrowSpeed;

    public CameraController theCam;

    public Transform camPoint;

    public float moveSpeed;

    public float launcherRotationSpeed;
    private float launcherRotation;

    public float waitToShot, timeBetweenShot;
    private float waitToShotCounter, timeBetweenShotCounter;
    public GameObject projectileToFire;
    public Transform[] firePoints;
    private int currentShot;

    private int currentPhase;
    // Start is called before the first frame update
    void Start()
    {
        theCam = FindFirstObjectByType<CameraController>();
        boss.transform.localScale = Vector3.zero;
        projectileLauncher.transform.localScale = Vector3.zero;
        waitToShotCounter = waitToShot;
        blocker.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            theCam.transform.position = Vector3.MoveTowards(theCam.transform.position, camPoint.position, moveSpeed * Time.deltaTime);
            if (boss.transform.localScale != Vector3.one)
            {
                boss.transform.localScale = Vector3.MoveTowards(boss.transform.localScale, Vector3.one, bossgrowSpeed * Time.deltaTime);
            }
            if (projectileLauncher.transform.localScale != Vector3.one)
            {
                projectileLauncher.transform.localScale = Vector3.MoveTowards(projectileLauncher.transform.localScale, Vector3.one, launchergrowSpeed * Time.deltaTime);
            }

            launcherRotation = (launcherRotation + launcherRotationSpeed * Time.deltaTime) % 360f;
            projectileLauncher.transform.localRotation = Quaternion.Euler(0f, 0f, launcherRotation);

            

            if (waitToShotCounter > 0)
            {
                waitToShotCounter -= Time.deltaTime;
                if (waitToShotCounter <= 0)
                {
                    timeBetweenShotCounter = timeBetweenShot;
                    FireShot();
                }
            }

            if (timeBetweenShotCounter > 0)
            {
                timeBetweenShotCounter -= Time.deltaTime;

                if (timeBetweenShotCounter <= 0)
                {
                    timeBetweenShotCounter = timeBetweenShot;
                    FireShot();
                }
            }

            if (isWeak == false)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, movePoint[currentMovePoint].position, bossMoveSpeed * Time.deltaTime);

                if (boss.transform.position == movePoint[currentMovePoint].position)
                {
                    currentMovePoint++;
                    if (currentMovePoint == movePoint.Length)
                    {
                        currentMovePoint = 0;
                    }
                }
            }
        }       
    }

    public void ActivateBattle()
    {
        isActive = true;
        blocker.SetActive(true);
        theCam.enabled = false;
        AudioManager.instance.PlayBossMusic();

    }

    public void FireShot()
    {
        Instantiate(projectileToFire, firePoints[currentShot].position, firePoints[currentShot].rotation);

        firePoints[currentShot].gameObject.SetActive(false);

        currentShot++;
        if (currentShot >= firePoints.Length)
        {
            timeBetweenShotCounter = 0;
            MakeWeak();
        }
        AudioManager.instance.PlaySFX(2);
    }

    public void MakeWeak()
    {
        bossAnim.SetTrigger("isWeak");
        isWeak = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (isWeak == false)
            {
                PlayerHealthController.instance.takeDamage(1);
            }
            else
            {
                if (collision.transform.position.y > boss.transform.position.y)
                {
                    bossAnim.SetTrigger("isHit");
                    PlayerController.instance.Jump();
                    NextPhase();
                }
            }
        }
    }

    private void NextPhase()
    {
        currentPhase++;
        if (currentPhase <= 3)
        {
            waitToShot *= 0.5f;
            timeBetweenShot *= 0.75f;
            currentShot = 0;
            bossMoveSpeed *= 1.2f;
            waitToShotCounter = waitToShot;
            projectileLauncher.transform.localScale = Vector3.zero;
            isWeak = false;
            foreach(Transform point in firePoints)
            {
                point.gameObject.SetActive(true);
            }
            AudioManager.instance.PlaySFX(1);
        }
        else
        {
            boss.SetActive(false);
            blocker.SetActive(false);
            Instantiate(bossDeathEffect, boss.transform.position, Quaternion.identity);
            theCam.enabled = true;
            AudioManager.instance.PlaySFX(0);
            AudioManager.instance.PlayLevelMusic(FindFirstObjectByType<LevelMusicPlayer>().trackToPlay);

        }
    }
}
