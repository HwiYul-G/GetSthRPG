using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;


    void Start()
    {
        
    }


    void LateUpdate()
    {
        if(this.transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, smoothing);
        }
    }
}
