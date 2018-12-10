using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour {

    public float speed;
    public float ShrinkPercent;
    Vector3 startsize;
	// Use this for initialization
	void Start () {
        startsize = transform.localScale;
        ShrinkPercent = 1;

    }
	
	// Update is called once per frame
	void Update () {
        if (ShrinkPercent > 0.01f)
            ShrinkPercent -= Time.deltaTime * speed;
        else
            ShrinkPercent = 0.01f;

        transform.localScale = startsize * ShrinkPercent;

    }
}
