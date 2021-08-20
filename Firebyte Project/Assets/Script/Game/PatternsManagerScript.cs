using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatternsManagerScript : MonoBehaviour
{
    public List<Transform> patternsList;
    public Transform currantPatterns;

    

    // Update is called once per frame
    void Update()
    {
        if (CheckDestance())
        {
            currantPatterns.transform.position = new Vector3(currantPatterns.position.x, currantPatterns.position.y, patternsList.LastOrDefault().transform.position.z + 60);
            patternsList.Remove(currantPatterns);
            patternsList.Add(currantPatterns);
            currantPatterns = patternsList.FirstOrDefault();
        }
    }

    public bool CheckDestance()
    {
        if (currantPatterns.position.z + 100 < GamePlayManagerScript.instance.player.transform.position.z)
            return true;
        else
            return false;
    }
}
