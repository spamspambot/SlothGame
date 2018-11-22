using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public float velocity = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetMouseButton(0)) leftArm.AddForceAtPosition(transform.up * velocity, leftArm.transform.position);
        if (Input.GetMouseButton(1)) rightArm.AddForceAtPosition(transform.up * velocity, rightArm.transform.position);
        */
     /*
     if (Input.GetMouseButton(0)) leftArm.AddTorque(leftArm.transform.up * velocity, ForceMode.Acceleration);
     if (Input.GetMouseButton(1)) rightArm.AddTorque(rightArm.transform.up * velocity, ForceMode.Acceleration);
     */
        if (Input.GetMouseButton(0)) leftArm.AddTorque(-transform.up * velocity, ForceMode.Acceleration);
        if (Input.GetMouseButton(1)) rightArm.AddTorque(transform.up * velocity, ForceMode.Acceleration);
    }
}
