using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isActive;
    public Animator theAnim;

    [HideInInspector]
    public CheckPointManager theCPM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isActive == false)
        {
            theCPM.SetActiveCP(this);
            theAnim.SetBool("isActive", true);
            isActive = true;
            AudioManager.instance.PlaySFX(3);
        }
    }

    public void DeactiveCheckPoint()
    {
        theAnim.SetBool("isActive", false);
        isActive = false;

    }
}
