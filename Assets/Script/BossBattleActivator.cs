using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleActivator : MonoBehaviour
{
    public BossBattleController theBoss;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            theBoss.ActivateBattle();
            gameObject.SetActive(false);
        }
    }
}
