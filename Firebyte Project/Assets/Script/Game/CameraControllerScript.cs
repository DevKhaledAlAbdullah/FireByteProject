using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    [Header("Controller")]
    public float smoothRate = 5;
    public Vector3 offset;
    public Transform target;
    
    private void Start()
    {
        offset = transform.position;
        Vector3 offsettedPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, offsettedPos,
            smoothRate * Time.fixedTime);
        transform.position = smoothedPos;
    }
    private void LateUpdate()
    {

        Vector3 offsettedPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, offsettedPos,
            smoothRate * Time.fixedDeltaTime);

        Vector3 lastPos = new Vector3(transform.position.x, smoothedPos.y, smoothedPos.z);
        transform.position = lastPos;
    }
}
