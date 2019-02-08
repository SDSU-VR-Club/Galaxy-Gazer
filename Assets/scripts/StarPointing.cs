using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//see Carter for more info
namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Hand))]
    public class StarPointing : MonoBehaviour {
        //where the hand beam points from
        public Transform shootTransform;
        Hand myHand;
        Color green;
        // Use this for initialization
        void Start() {
            myHand = GetComponent<Hand>();
            green = new Color(0, 1, 0);
        }
        //shoots beam to highlight hovered stars
        private void LateUpdate()
        {
            RaycastHit hit;
            if (Physics.Raycast(shootTransform.position, shootTransform.forward, out hit))
            {
                if (hit.collider.gameObject.GetComponent<StarBehavior>() != null)
                {
                    hit.collider.gameObject.GetComponent<StarBehavior>().highlight();
                    GetComponentInChildren<LineRenderer>().startColor = Color.blue;
                    GetComponentInChildren<LineRenderer>().endColor = Color.blue;
                }
            }
            else
            {
                GetComponentInChildren<LineRenderer>().startColor = Color.white;
            }
        }
        //Called on trigger press to select a star if pointed one is being pointed at
        void Update() {
            RaycastHit hit;
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                
                if (Physics.Raycast(shootTransform.position, shootTransform.forward,out hit))
                {
                    if (hit.collider.gameObject.GetComponent<StarBehavior>() != null)
                    {
                        hit.collider.gameObject.GetComponent<StarBehavior>().select();
                    }
                }
            }

    }
    }
}