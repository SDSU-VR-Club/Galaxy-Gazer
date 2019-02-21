using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restrictmovement : MonoBehaviour
{
    public Transform tracking;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - tracking.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tracking.position + offset;
    }
}
