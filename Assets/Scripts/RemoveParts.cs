using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParts : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (rb.useGravity == true)
        {
            if (transform.position.y <= 10) //Removes the parts from under the map.
            {
                Destroy(gameObject);
            }
        }
    }
}
