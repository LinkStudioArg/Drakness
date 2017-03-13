using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraFollow : MonoBehaviour {


    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
   
    

    float x = 0.0f;
   

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        
    }

    void LateUpdate()
    {
        if (target)
        {
            x += CrossPlatformInputManager.GetAxis("Horizontal") * xSpeed * distance * 0.01f;
           

            Quaternion rotation = Quaternion.Euler(30, x, 0);
            

            
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
