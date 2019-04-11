using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TrailRenderer>().emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TrailRenderer>().emitting = true;
    }
}
