using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAdjustment : MonoBehaviour
{
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = false;
    }
    private void Awake()
    {
        GetComponent<Camera>().fieldOfView -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            GetComponent<Camera>().enabled = true;
            started=true;
        }
    }
}
