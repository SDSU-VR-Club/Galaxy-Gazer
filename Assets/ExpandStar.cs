using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandStar : MonoBehaviour {

    public GameObject player;
    public float speed;
    Transform[] stars;
    public Vector3 average;
    int i;
    // Use this for initialization
    void Start () {
        stars = GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {


        for (i = 0; i < stars.Length; i++)
        {
            if(stars[i].tag == ("Star"))
            average += stars[i].position;
        }
        average /= i;

        for (i = 0; i < stars.Length; i++)
        {
            if (stars[i].tag == ("Star"))
                stars[i].position += (stars[i].position - average)*speed/100;
        }

        transform.position = transform.position - player.transform.position;
    }
}
