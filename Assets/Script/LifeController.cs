using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    public float moveSpeed;

    private void Awake()
    {
        instance = this;
    }

    private PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        thePlayer.gameObject.SetActive(false);
        StartCoroutine(RespawnCo());
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
}
