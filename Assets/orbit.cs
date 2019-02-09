using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour {

    float x;
    float z;
    public float Speed;
    public float Xwidth;
    public float Zwidth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        x = Mathf.Sin(Time.time * Speed) * Xwidth;
        z = Mathf.Cos(Time.time * Speed) * Zwidth;

        transform.position = new Vector3(x, 0, z);
	}
}
