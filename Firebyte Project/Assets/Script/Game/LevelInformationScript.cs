using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformationScript : MonoBehaviour
{

    public int finishLineDistance;
    // on start funcation we set distance finish line .
    void Start()
    {
        GamePlayManagerScript.instance.finishLine.position = new Vector3(GamePlayManagerScript.instance.finishLine.position.x, GamePlayManagerScript.instance.finishLine.position.y, finishLineDistance);
    }

   
}
