using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class laserPointer : MonoBehaviour {
    LineRenderer lr;
    public float range = 100;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + transform.forward * range);
	}
}
