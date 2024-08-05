using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentHealth, maxHealth;
    public float invincibleTime;
    private float invincibleTimeCounter;

    public SpriteRenderer theSR;
    public Color normalColor, fadeColor;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleTimeCounter > 0)
        {
            invincibleTimeCounter -= Time.deltaTime;

            if (invincibleTimeCounter < 0)
            {
                theSR.color = normalColor;
            }
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            addHealth(1);
        }
#endif
    }

    public void takeDamage(int damageToTake)
    {
        if (invincibleTimeCounter <= 0)
        {

            

            currentHealth -= damageToTake;
            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                invincibleTimeCounter = invincibleTime;
                theSR.color = fadeColor;
                PlayerController.instance.KnockBack();

            }
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
    }

    public void addHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }
}
