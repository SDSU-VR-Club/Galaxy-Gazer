using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEdgeColliders : MonoBehaviour {

    public float scale;
    public float dist;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            dist = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
            float i = dist / Mathf.Pow(scale, -1) / 10;
            child.localScale = new Vector3(i, i, -i);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        
    }
}
