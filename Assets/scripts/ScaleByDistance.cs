using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByDistance : MonoBehaviour {

    public float scale;
    GameObject cam;
    float dist;

    public GameObject hit;

	// Use this for initialization
	void Start () {
        cam = Camera.main.gameObject;

       // GameObject x = Instantiate(hit, transform.position, Quaternion.identity);
       // x.transform.position -= new Vector3(0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(gameObject.transform.position, cam.transform.position);
        float i = dist / Mathf.Pow(scale,-1) / 10;
        transform.localScale = new Vector3(i, i, i);
        GetComponent<TrailRenderer>().startWidth = i;
    }
}
