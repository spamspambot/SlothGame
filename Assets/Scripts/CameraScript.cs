using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<GameObject> targets;
    public Camera cam;
    public Vector3 camTarget;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startPos = cam.transform.position;
     //   if (targets.Count == 1) camTarget = targets[0].transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 1)
        {
            camTarget = targets[0].transform.position + (targets[1].transform.position - targets[0].transform.position) / 2;
        }
        else 
        cam.transform.position = targets[0].transform.position + startPos;
    }
}
