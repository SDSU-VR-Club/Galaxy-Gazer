using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flareConverter : MonoBehaviour {
    bool first = true;
	// Use this for initialization
	void Start () {
        GetComponent<LensFlare>().color = GetComponent<MeshRenderer>().material.color;
        GetComponent<LensFlare>().brightness = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (first)
        {
            
            first = false;
        }

	}
}
