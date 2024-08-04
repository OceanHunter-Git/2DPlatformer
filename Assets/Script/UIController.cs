using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }
    public Image[] heartIcon;

    public Sprite heartFull, heartEmpty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
