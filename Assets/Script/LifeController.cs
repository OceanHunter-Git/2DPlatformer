using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;

    private void Awake()
    {
        instance = this;
    }


    public int currentLive;
    public float moveSpeed;
    public float gameoverDelay;

    private PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        UIController.instance.liveDisplay(currentLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        thePlayer.gameObject.SetActive(false);
        thePlayer.theRb.velocity = Vector2.zero;

        currentLive--;
        
        if (currentLive > 0)
        {
            StartCoroutine(RespawnCo());
        }
        else
        {
            currentLive = 0;
            Gameover();
        }
        UIController.instance.liveDisplay(currentLive);

    }

    public IEnumerator RespawnCo()
    {
        while (thePlayer.transform.position != CheckPointManager.instance.respawnPoint)
        {
            thePlayer.transform.position = Vector3.MoveTowards(thePlayer.transform.position, CheckPointManager.instance.respawnPoint, moveSpeed * Time.deltaTime);
            yield return null;
        }
        PlayerHealthController.instance.addHealth(PlayerHealthController.instance.maxHealth);
        thePlayer.gameObject.SetActive(true);
    }

    public void Gameover()
    {
        UIController.instance.ShowGameOver();
    }
}
