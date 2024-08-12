using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public Animator theAnim;

    public GameObject Blocker;

    public bool isEnd;

    public float nextDelay;

    public float fadeTime;

    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnd == false)
        {
            if (other.CompareTag("Player"))
            {
                isEnd = true;
                Blocker.SetActive(true);
                theAnim.SetTrigger("Ended");
                AudioManager.instance.PlayVictoryMusic();
                StartCoroutine(LevelEndCo());
            }
        }    
    }

    IEnumerator LevelEndCo()
    {
        yield return new WaitForSeconds(nextDelay - fadeTime);
        UIController.instance.FadeToBlack();
        InfoTracker.instance.GetInfo();
        InfoTracker.instance.SaveInfo();
        PlayerPrefs.SetString("currentLevel", nextLevelName);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextLevelName);
    }
}
