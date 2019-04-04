using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//see Carter for more info
namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Hand))]
    public class StarPointing : MonoBehaviour {
        //where the hand beam points from
        Hand myHand;
        Color green;
        GameObject lastSelectedObject;
        public int DecimalPlaces;
        bool started=false;
        // Use this for initialization
        void Start() {
            myHand = GetComponent<Hand>();
            green = new Color(0, 1, 0);
            StartCoroutine(begin());
        }
        private IEnumerator begin()
        {
            yield return new WaitForSeconds(0.1f);
            started = true;
        }
        //shoots beam to highlight hovered stars
        private void LateUpdate()
        {
            if (started)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<StarBehavior>() != null)
                    {
                        if (lastSelectedObject != null)
                        {
                            lastSelectedObject.GetComponent<StarBehavior>().dehighlight();
                        }
                        hit.collider.gameObject.GetComponent<StarBehavior>().highlight();
                        GetComponentInChildren<LineRenderer>().startColor = Color.blue;
                        GetComponentInChildren<LineRenderer>().endColor = Color.blue;
                        lastSelectedObject = hit.collider.gameObject;
                    }
                }
                else
                {
                    GetComponentInChildren<LineRenderer>().startColor = Color.white;
                }
            }
        }
        //Called on trigger press to select a star if pointed one is being pointed at
        void Update() {
            RaycastHit hit;
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {

                lastSelectedObject.GetComponent<StarBehavior>().select();
                //if (Physics.Raycast(transform.position, transform.forward, out hit))
                //{
                //    if (hit.collider.gameObject.GetComponent<StarBehavior>() != null)
                //    {
                //        hit.collider.gameObject.GetComponent<StarBehavior>().select();
                //    }
                //}
            }
           

    }




    }
}