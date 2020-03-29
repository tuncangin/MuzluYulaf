using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCam : MonoBehaviour
{
    CameraMovement cam;
    float mSense = 0250f;
    public Transform pivotCam;
    
    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime*mSense;
        pivotCam.Rotate(Vector3.up * mouseX);


    }
}
