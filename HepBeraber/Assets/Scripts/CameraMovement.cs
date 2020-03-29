using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mSense = 250f;
    

    float xRotation;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mSense * Time.deltaTime;   
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 10f, 40f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);




    }
}
