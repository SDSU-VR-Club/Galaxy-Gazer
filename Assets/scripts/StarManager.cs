using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {
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
        if (stars == null) {
            stars = new List<Transform>();
            var starbehaviors = FindObjectsOfType<StarBehavior>();
            foreach (StarBehavior a in starbehaviors)
                stars.Add(a.transform);
                }
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
        if (closestStar==starToCheck)
        {
            starToCheck.success();
            goodSound.Play();
            stars.Remove(closestStar.transform);
            if (stars.Count == 0)
                GetComponent<UIManager>().gameOver((int) score);
            return;

        }

        starToCheck.fail();
        badSound.Play();
        score++;

    }
}
