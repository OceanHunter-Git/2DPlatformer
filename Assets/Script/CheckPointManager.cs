using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public CheckPoint[] theCP;
    private CheckPoint activeCP;
    // Start is called before the first frame update
    void Start()
    {
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
    }


}
