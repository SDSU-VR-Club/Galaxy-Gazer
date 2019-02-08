using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//carter code
public class flareConverter : MonoBehaviour {
    bool first = true;
	// Use this for initialization
	void Start () {
        GetComponent<LensFlare>().color = GetComponent<MeshRenderer>().material.color;
        GetComponent<LensFlare>().brightness = transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        //changes the color of the light from a star to be the same as its material color
        GetComponent<LensFlare>().color = GetComponent<MeshRenderer>().material.color;
        //GetComponent<LensFlare>().brightness = transform.localScale.x;
       
    }
}
