using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float lifetime = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObject() {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

}
