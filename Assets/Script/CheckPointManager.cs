using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    private void Awake()
    {
        instance = this;
    }

    public CheckPoint[] theCP;
    private CheckPoint activeCP;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = PlayerController.instance.transform.position;
        theCP = FindObjectsByType<CheckPoint>(FindObjectsSortMode.None);
        foreach(CheckPoint cp in theCP)
        {
            cp.theCPM = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactiveAllCP()
    {
        foreach (CheckPoint cp in theCP)
        {
            cp.DeactiveCheckPoint();
        }
    }

    public void SetActiveCP(CheckPoint newCP)
    {
        DeactiveAllCP();
        activeCP = newCP;
        respawnPoint = newCP.transform.position;
    }


}
