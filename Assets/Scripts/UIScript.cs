using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public List<RagdollController> controllers;
    public List<Image> bars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bars.Count; i++) {
            bars[i].fillAmount = 1 - (controllers[i].sleepCounter / controllers[i].sleepThreshold);
        }
    }
}
