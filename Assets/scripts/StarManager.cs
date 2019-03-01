using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//see Carter for more info
namespace Valve.VR.InteractionSystem
{
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
        // Use this for initialization
        void Start() {

        }
        public void Begin()
        {
            var tmp = Instantiate(constellations[currentIndex++]);
            tmp.transform.position = SpawnPosition.position;
            currentConstellation = tmp;
        }
        // Update is called once per frame
        void Update() {

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
            StarBehavior closestStar = null;
            foreach (Transform a in stars)
            {
                var dist = Vector3.Distance(Camera.main.transform.position, a.position);
                if (dist < lowest)
                {
                    lowest = dist;
                    closestStar = a.GetComponent<StarBehavior>();
                }
            }
            //compare closest star with user selection to determine success
            if (closestStar == starToCheck)
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
        public void nextConstellation()
        {
            //score screen pops up


            StartCoroutine(cycleConstellation());
        }
        private IEnumerator cycleConstellation()
        {
            score = 0;
            Destroy(currentConstellation);
            stars = null;
            yield return new WaitForSeconds(3);
            if (currentIndex == constellations.Length)
            {
                SceneManager.MoveGameObjectToScene(FindObjectOfType<Player>().gameObject, SceneManager.GetActiveScene());
                Application.LoadLevel(Application.loadedLevel + 1);
            }

            var tmp = Instantiate(constellations[currentIndex++]);
            tmp.transform.position = SpawnPosition.position;
            currentConstellation = tmp;

        }
    }
}