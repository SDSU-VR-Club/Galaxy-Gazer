using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByDistance : MonoBehaviour {

    public float scale;
    GameObject cam;
    float dist;

	// Use this for initialization
	void Start () {
        cam = Camera.main.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(gameObject.transform.position, cam.transform.position);
        float i = dist / Mathf.Pow(scale,-1) / 10;
        transform.localScale = new Vector3(i, i, i);
        GetComponent<TrailRenderer>().startWidth = i;
	}
}
