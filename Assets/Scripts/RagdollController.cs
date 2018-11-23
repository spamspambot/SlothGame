using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public Transform leftShoulder;
    public Transform rightShoulder;
    public CharacterJoint leftElbow;
    public CharacterJoint rightElbow;
    public float shoulderBendL;
    public float maxShoulderBend;
    SoftJointLimit leftLimit;
    SoftJointLimit leftLimit2;
    SoftJointLimit rightLimit;
    public float velocity = 500;
    public float limitChange = 1;
    public float x;
    public float y;
    Vector3 shoulderR;
    Vector3 shoulderL;
    // Start is called before the first frame update
    void Start()
    {
        leftLimit = leftElbow.lowTwistLimit;
        leftLimit2 = leftElbow.highTwistLimit;
        shoulderR = rightShoulder.rotation.eulerAngles;
        shoulderL = leftShoulder.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        leftShoulder.rotation = Quaternion.Euler(shoulderL.x, shoulderL.y, shoulderL.z + shoulderBendL);

        /*
        if (Input.GetMouseButton(0))
        {
            shoulderBendL++;
            // leftArm.rotation = Quaternion.Euler(0,0,0);
        }
        else shoulderBendL--;

        shoulderBendL = Mathf.Clamp(shoulderBendL, 0, maxShoulderBend);
        if (Input.GetMouseButton(1)) { rightArm.AddForceAtPosition(rightArm.transform.up * velocity, rightArm.transform.position); }

        */
        /*
                if (Input.GetMouseButton(0))
                {
                    leftArm.AddForceAtPosition(leftArm.transform.up * velocity, leftArm.transform.position);
                    leftLimit.limit = Mathf.Clamp(leftLimit.limit - limitChange, -170, 170);

                    leftLimit2.limit = Mathf.Clamp(leftLimit2.limit - limitChange, -170, 170);
                    print("1 "+ leftLimit.limit);
                    print("2 " + leftLimit2.limit);
                }
                //  else { leftLimit.limit = leftLimit.limit + limitChange; leftLimit2.limit = leftLimit2.limit + limitChange; }

                if (Input.GetMouseButton(1)) { rightArm.AddForceAtPosition(rightArm.transform.up * velocity, rightArm.transform.position); }
          */    


         if (Input.GetMouseButton(0)) leftArm.AddTorque(Vector3.up * velocity, ForceMode.Acceleration);
         if (Input.GetMouseButton(1)) rightArm.AddTorque(Vector3.up * velocity, ForceMode.Acceleration);
        /*
          if (Input.GetMouseButton(0)) leftArm.AddTorque(-transform.up * velocity, ForceMode.Acceleration);
        if (Input.GetMouseButton(1)) rightArm.AddTorque(transform.up * velocity, ForceMode.Acceleration);*/
    }
}
