using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleMeasure : MonoBehaviour {

    public GameObject Star1;
    public GameObject Star2;

    public Vector3 v1;
    public Vector3 v2;

    public float angle;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        v1 = transform.position - Star1.transform.position;
        v2 = transform.position - Star2.transform.position;
        angle = Vector3.Angle(v1, v2);
    }
}
