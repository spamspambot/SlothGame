using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public CharacterJoint leftElbow;
    public CharacterJoint rightElbow;
    SoftJointLimit leftLimit;
    SoftJointLimit leftLimit2;
    SoftJointLimit rightLimit;
    public float velocity = 500;
    public float limitChange = 1;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        leftLimit = leftElbow.lowTwistLimit;
        leftLimit2 = leftElbow.highTwistLimit;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
                if (Input.GetMouseButton(0))
                {
                    leftArm.AddForceAtPosition(transform.forward * velocity, leftArm.transform.position);
                    leftLimit.limit = Mathf.Clamp(leftLimit.limit - limitChange, -170,170);
                    print(leftLimit.limit);
                    leftLimit2.limit = leftLimit2.limit - limitChange;
                }
              //  else { leftLimit.limit = leftLimit.limit + limitChange; leftLimit2.limit = leftLimit2.limit + limitChange; }

                if (Input.GetMouseButton(1)) { rightArm.AddForceAtPosition(transform.forward * velocity, rightArm.transform.position); }
               


      //  if (Input.GetMouseButton(0)) leftArm.AddTorque(transform.forward * velocity, ForceMode.Acceleration);
      //  if (Input.GetMouseButton(1)) rightArm.AddTorque(transform.forward * velocity, ForceMode.Acceleration);
        /*
          if (Input.GetMouseButton(0)) leftArm.AddTorque(-transform.up * velocity, ForceMode.Acceleration);
        if (Input.GetMouseButton(1)) rightArm.AddTorque(transform.up * velocity, ForceMode.Acceleration);*/
    }
}
