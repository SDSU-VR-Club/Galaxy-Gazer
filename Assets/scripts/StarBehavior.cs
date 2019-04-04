using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//see Carter for more info
public class StarBehavior : MonoBehaviour {
    //has the star been correctly selected
    bool finished = false;
    //has the star been falsely selected (only true for limited time)
    bool failing = false;
    Color originalColor;
    TextMeshProUGUI StarNameText;
    // Use this for initialization
    void Start () {

        //gets textmesh and sets name
        StarNameText = transform.Find("StarNameCanvas/NameOfStar").GetComponent<TextMeshProUGUI>();
        StarNameText.text = gameObject.name;

        //so we can get back to the color we started at when we highlight
        originalColor = GetComponent<SpriteRenderer>().color;
        
    }
	
	// Update is called once per frame
	void Update () {
        //if 
        //dehighlight();
	}
    public void select()
    {
        if (!finished&&!failing)
        {
            FindObjectOfType<StarManager>().checkClosest(this);
            
        }
    }
    //called in the event a star is successfully selected
    public void success()
    {
        GetComponent<TEXTSHOW>().Hitnow();
        GetComponent<SpriteRenderer>().color=Color.green;
        finished = true;
    }
    //turns the star red for 2 sec and prevents it from being selected again rapidly
    public void fail()
    {
        
        StartCoroutine(red());
        
    }
    private IEnumerator red()
    {
        failing = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().color = originalColor;
        failing = false;
    }
    //called when a star is hovered over
    public void highlight()
    {
        StarNameText.color += new Color(0, 0, 0, 1);

        //print("The quick brown fox");
        if (!finished && !failing)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
        }
    }
    //called every frame to counteract highlight
    public void dehighlight()
    {
        StarNameText.color -= new Color(0, 0, 0, 1);

        if (!finished && !failing)
        {
            GetComponent<SpriteRenderer>().color = originalColor;
        }
    }


}
