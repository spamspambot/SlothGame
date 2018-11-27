using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int powerID;
    public GameObject sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sloth")) {
            Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
