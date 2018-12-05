using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {
    bool finished = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void select()
    {
        if (!finished)
        {
            FindObjectOfType<StarManager>().checkClosest(this);
            
        }
    }
    public void success()
    {
        GetComponent<LensFlare>().color = Color.green;
        finished = true;
    }
    public void fail()
    {
        StartCoroutine(red());
    }
    private IEnumerator red()
    {
        var originalColor = GetComponent<LensFlare>().color;
        GetComponent<LensFlare>().color = Color.black;
        yield return new WaitForSeconds(2);
        GetComponent<LensFlare>().color = originalColor;
    }
}
