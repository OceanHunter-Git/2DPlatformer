using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTracker : MonoBehaviour
{
    public static InfoTracker instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.HasKey("live"))
            {
                currentLives = PlayerPrefs.GetInt("live");
                currentFruit = PlayerPrefs.GetInt("fruit");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int currentLives, currentFruit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInfo()
    {
        currentFruit = FruitPickUpManager.instance.currentFruitAmount;

        currentLives = LifeController.instance.currentLive;
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetInt("fruit", currentFruit);
        PlayerPrefs.SetInt("live", currentLives);
    }
}
