using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//see Carter for more info
public class StarManager : MonoBehaviour {
    //poulated on the first selection with all stars in the scene
    List<Transform> stars;
    public float score = 0;
    public AudioSource badSound;
    public AudioSource goodSound;
    public GameObject currentConstellation;
    public GameObject[] constellations;
    int currentIndex = 0;
    public Transform SpawnPosition;
    public Vector3 onlyYpos; //position of head but only height, used for star spawning location
    // Use this for initialization
    Transform center;
    bool movingIn;
    Vector3 target;
    public GameObject continueButton;
    void Start () {
        Begin();
	}
	public void Begin()
    {
        TEXTSHOW.count = 1;
        //FindObjectOfType<PlayerRotate>().playerRotate();
        var tmp = Instantiate(constellations[currentIndex++]);
        SpawnPosition = Camera.main.transform;
        onlyYpos = new Vector3(0, SpawnPosition.position.y, 0);
        tmp.transform.position = onlyYpos;
        //tmp.transform.position = SpawnPosition.position;
        currentConstellation = tmp;
    }
	// Update is called once per frame
	void Update () {
        if (movingIn)
        {
            center.position = Vector3.Lerp(center.position,target , 0.005f);
        }
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
            var dist = Vector3.Distance(onlyYpos, a.position);
            //var dist = Vector3.Distance(SpawnPosition.position, a.position);
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
            {
                GetComponent<UIManager>().nextUI((int)score);
                nextConstellation();
            }
            return;

        }
        //in the event of a failure
        starToCheck.fail();
        badSound.Play();
        score++;
       
    }
    public void goToZero()
    {
        foreach(ScaleByDistance a in currentConstellation.GetComponentsInChildren<ScaleByDistance>())
        {
            a.enabled = false;
            a.gameObject.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
        movingIn = true;
        target = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        center = new GameObject().transform;
        foreach (Transform a in currentConstellation.transform) {
            center.position += a.position;
                }
        center.position /= currentConstellation.transform.childCount;

        currentConstellation.transform.parent = center;
        GameObject.Find("Sun").transform.parent = center;
    }
    public void nextConstellation()
    {
        //score screen pops up


        StartCoroutine(cycleConstellation());
    }
    private IEnumerator cycleConstellation()
    {
        score = 0;
        
        stars = null;
        yield return new WaitForSeconds(3);
        goToZero();
        yield return new WaitForSeconds(7);
        Instantiate(continueButton,center);
    }
    public void forceChangeConstellation()
    {
        print("change");
        movingIn = false;
        GameObject.Find("Sun").transform.parent = null;
        GameObject.Find("Sun").transform.position = Vector3.zero;
        Destroy(currentConstellation);
        Destroy(center.gameObject);
        if (currentIndex == constellations.Length)
        {
            TEXTSHOW.count = 1;
            Destroy(FindObjectOfType<PlayerRotate>().gameObject);
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else
        {
            var tmp = Instantiate(constellations[currentIndex++]);
            TEXTSHOW.count = 1;
            tmp.transform.position = onlyYpos;
            //tmp.transform.position = SpawnPosition.position;
            currentConstellation = tmp;
        }
    }
}
