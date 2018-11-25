using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public int ID;
    public GameObject sleepObject;
    public Transform head;
    public bool iGaveUp;
    public bool tryToBend;
    public bool sleeping;
    public int sleepCounter;
    public int sleepThreshold;
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public Transform leftShoulder;
    public Transform rightShoulder;
    public float bendSpeed;
    public CharacterJoint leftElbow;
    public CharacterJoint rightElbow;
    public float shoulderBendL;
    public float maxShoulderBend;
    public float shoulderBendXL;
    public float maxShoulderBendX;
    public float minShoulderBendX;
    SoftJointLimit leftLimit;
    SoftJointLimit leftLimit2;
    SoftJointLimit rightLimit;
    public float velocity = 500;
    public float limitChange = 1;
    public float x;
    public float y;
    public int armCounter;
    int leftCounter;
    int rightCounter;
    Vector3 shoulderR;
    Vector3 shoulderL;
    public AudioSource AS;
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
        if (!sleeping)
        {
            if (sleepCounter >= sleepThreshold) StartCoroutine("FallAsleep");
            if (iGaveUp)
            {
                if (Input.GetMouseButton(0)) { leftArm.AddForceAtPosition(transform.up * velocity, leftArm.transform.position, ForceMode.Force); }
                else if (Input.GetMouseButton(1)) { rightArm.AddForceAtPosition(transform.up * velocity, rightArm.transform.position, ForceMode.Force); }
                if (Input.GetMouseButtonDown(0)) { leftArm.AddForceAtPosition(-transform.forward * velocity / 10, leftArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                else if (Input.GetMouseButtonDown(1)) { rightArm.AddForceAtPosition(-transform.forward * velocity / 10, rightArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                if (ID == 1)
                {

                    if (Input.GetButton("LEFT_1") && leftCounter < armCounter) { leftArm.AddForceAtPosition(transform.up * velocity, leftArm.transform.position, ForceMode.Force); leftCounter++; }
                    if (Input.GetButton("RIGHT_1") && rightCounter < armCounter) { rightArm.AddForceAtPosition(transform.up * velocity, rightArm.transform.position, ForceMode.Force); rightCounter++; }
                    if (Input.GetButtonDown("LEFT_1")) { leftArm.AddForceAtPosition(-transform.forward * velocity / 10, leftArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                    if (Input.GetButtonDown("RIGHT_1")) { rightArm.AddForceAtPosition(-transform.forward * velocity / 10, rightArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                    if (Input.GetButtonUp("LEFT_1")) { leftCounter = 0; }
                    if (Input.GetButtonUp("RIGHT_1")) { rightCounter = 0; }
                }
                else if (ID == 2)
                {

                    if (Input.GetButton("LEFT_2")) { leftArm.AddForceAtPosition(transform.up * velocity, leftArm.transform.position, ForceMode.Force); }
                    else if (Input.GetButton("RIGHT_2")) { rightArm.AddForceAtPosition(transform.up * velocity, rightArm.transform.position, ForceMode.Force); }
                    if (Input.GetButtonDown("LEFT_2")) { leftArm.AddForceAtPosition(-transform.forward * velocity / 10, leftArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                    else if (Input.GetButtonDown("RIGHT_2")) { rightArm.AddForceAtPosition(-transform.forward * velocity / 10, rightArm.transform.position, ForceMode.Impulse); sleepCounter++; }
                }
            }
            else
            {
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");
                //  

                if (tryToBend)
                {
                    leftShoulder.rotation = Quaternion.Euler(shoulderL.x, shoulderL.y, shoulderL.z);
                    //    leftShoulder.rotation = Quaternion.Euler(shoulderL.x + shoulderBendXL, shoulderL.y, shoulderL.z + shoulderBendL);
                    if (Input.GetMouseButton(0))
                    {
                        shoulderBendL++;
                        shoulderBendXL++;
                        // leftArm.rotation = Quaternion.Euler(0,0,0);
                    }
                    else
                    {
                        shoulderBendL--;
                        shoulderBendXL--;
                    }
                    shoulderBendL = Mathf.Clamp(shoulderBendL, 0, maxShoulderBend);
                    shoulderBendXL = Mathf.Clamp(shoulderBendXL, minShoulderBendX, maxShoulderBendX);

                    // if (Input.GetMouseButton(1)) { rightArm.AddForceAtPosition(rightArm.transform.up * velocity, rightArm.transform.position); }
                }
                else
                {
                    if (Input.GetMouseButton(0)) leftArm.AddTorque(-leftArm.transform.right * velocity, ForceMode.Acceleration);
                    if (Input.GetMouseButton(1)) rightArm.AddTorque(rightArm.transform.right * velocity, ForceMode.Acceleration);
                }

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


                /*
                  if (Input.GetMouseButton(0)) leftArm.AddTorque(-transform.up * velocity, ForceMode.Acceleration);
                if (Input.GetMouseButton(1)) rightArm.AddTorque(transform.up * velocity, ForceMode.Acceleration);*/
            }
        }
    }
    IEnumerator FallAsleep()
    {
        Instantiate(sleepObject, head.position, Quaternion.Euler(270, 0, 0));
        sleepCounter = 0;
        sleeping = true;
        int RNG = 3;
        yield return new WaitForSeconds(RNG);
        sleeping = false;
    }

}
