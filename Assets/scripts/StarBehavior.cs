using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {
    bool finished = false;
    bool failing = false;
    Color originalColor;
	// Use this for initialization
	void Start () {
        originalColor = GetComponent<MeshRenderer>().material.color;
        
    }
	
	// Update is called once per frame
	void Update () {
        dehighlight();
	}
    public void select()
    {
        if (!finished&&!failing)
        {
            FindObjectOfType<StarManager>().checkClosest(this);
            
        }
    }
    public void success()
    {
        GetComponent<MeshRenderer>().material.color=Color.green;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
        finished = true;
    }
    public void fail()
    {
        failing = true;
        StartCoroutine(red());
        
    }
    private IEnumerator red()
    {
        
        GetComponent<MeshRenderer>().material.color = Color.red;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(2);
        GetComponent<MeshRenderer>().material.color = originalColor;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", originalColor); 
        failing = false;
    }
    public void highlight()
    {
        if (!finished && !failing)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.blue);
        }
    }
    public void dehighlight()
    {
        if (!finished && !failing)
        {
            GetComponent<MeshRenderer>().material.color = originalColor;
            GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", originalColor);
        }
    }
}
