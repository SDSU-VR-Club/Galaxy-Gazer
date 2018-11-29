using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRotation : MonoBehaviour {
    public Vector3 rotationPerFrame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationPerFrame);
	}
}
