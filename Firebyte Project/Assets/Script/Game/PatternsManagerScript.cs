using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// usefull to move city in background scene 
/// </summary>
public class PatternsManagerScript : MonoBehaviour
{
    public List<Transform> patternsList;
    public Transform currantPatterns;

    

    /// <summary>
    /// set the first element in list (First city(Pattern)) in last element postion 
    /// </summary>
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
