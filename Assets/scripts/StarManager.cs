using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//see Carter for more info
public class StarManager : MonoBehaviour {
    //poulated on the first selection with all stars in the scene
    List<Transform> stars;
    public float score = 0;
    public AudioSource badSound;
    public AudioSource goodSound;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkClosest(StarBehavior starToCheck)
    {
        //initialize list of star transforms
        if (stars == null) {
            stars = new List<Transform>();
            var starbehaviors = FindObjectsOfType<StarBehavior>();
            foreach (StarBehavior a in starbehaviors)
                stars.Add(a.transform);
                }
        //sort for the closest star
        float lowest = Mathf.Infinity;
        StarBehavior closestStar=null;
        foreach(Transform a in stars)
        {
            var dist = Vector3.Distance(Camera.main.transform.position, a.position);
            if (dist < lowest)
            {
                lowest = dist;
                closestStar = a.GetComponent<StarBehavior>();
            }
        }
        //compare closest star with user selection to determine success
        if (closestStar==starToCheck)
        {
            //in the event of a success
            starToCheck.success();
            goodSound.Play();
            stars.Remove(closestStar.transform);
            if (stars.Count == 0)
                GetComponent<UIManager>().gameOver((int) score);
            return;

        }
        //in the event of a failure
        starToCheck.fail();
        badSound.Play();
        score++;

    }
}
