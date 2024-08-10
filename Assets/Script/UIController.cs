using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }
    public Image[] heartIcon;

    public Sprite heartFull, heartEmpty;

    public TMP_Text liveText;

    public TMP_Text fruitText;

    public GameObject gameoverPanel;
    public GameObject pausePanel;

    public float transformSpeed;

    public string menuName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndUnPause();
        }    
    }

    public void UpdateHealthDisplay(int health, int maxHealth)
    {
        for (int i = 0; i < heartIcon.Length; i++)
        {
            if (i < health)
            {
                heartIcon[i].sprite = heartFull;
            }
            else if (i < maxHealth)
            {
                heartIcon[i].sprite = heartEmpty;
            }
            else
            {
                heartIcon[i].enabled = false;
            }
        }
    }

    public void LiveDisplay(int currentLive)
    {
        liveText.text = "X" + currentLive.ToString();
    }

    public void FruitDisplay(int currentFruit)
    {
        fruitText.text = currentFruit.ToString();
    }

    public void ShowGameOver()
    {
        StartCoroutine(ShowGameOverCo()); 
    }

    public IEnumerator ShowGameOverCo()
    {
        gameoverPanel.transform.localScale = Vector3.zero;
        gameoverPanel.SetActive(true);
        while (gameoverPanel.transform.localScale != Vector3.one)
        {
            gameoverPanel.transform.localScale = Vector3.MoveTowards(gameoverPanel.transform.localScale, Vector3.one, transformSpeed * Time.deltaTime);
            yield return null;
        }   
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuName);
        Time.timeScale = 1f;
    }

    public void PauseAndUnPause()
    {
        if (Time.timeScale == 1)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
