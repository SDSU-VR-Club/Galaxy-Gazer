using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//kain kode
public class ScaleByDistance : MonoBehaviour {

    public float distanceExponent;
    GameObject cam;
    float dist;
    float initialScale;
    public GameObject hit;

	// Use this for initialization
	void Start () {
        cam = Camera.main.gameObject;
        initialScale = transform.localScale.x;
       // GameObject x = Instantiate(hit, transform.position, Quaternion.identity);
       // x.transform.position -= new Vector3(0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(gameObject.transform.position, cam.transform.position);
        float i = Mathf.Pow(dist, distanceExponent);
        transform.localScale = new Vector3(i, i, i) * initialScale;
        GetComponent<TrailRenderer>().startWidth = i;
    }
}
