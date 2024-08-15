using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
    public float bounceAmount;

    public Animator theAnim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            theAnim.SetTrigger("Bounce");
            PlayerController.instance.Bounce(bounceAmount);
        }
    }
}
