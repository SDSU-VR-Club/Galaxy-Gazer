using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Hand))]
    public class StarPointing : MonoBehaviour {
        public Transform shootTransform;
        Hand myHand;
        Color green;
        // Use this for initialization
        void Start() {
            myHand = GetComponent<Hand>();
            green = new Color(0, 1, 0);
        }

        private void LateUpdate()
        {
            RaycastHit hit;
            if (Physics.Raycast(shootTransform.position, shootTransform.forward, out hit))
            {
                hit.collider.gameObject.GetComponent<StarBehavior>().highlight();
                GetComponentInChildren<LineRenderer>().startColor = Color.blue;
                GetComponentInChildren<LineRenderer>().endColor = Color.blue;
            }
            else
            {
                GetComponentInChildren<LineRenderer>().startColor = Color.white;
            }
        }
        // Update is called once per frame
        void Update() {
            RaycastHit hit;
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                
                if (Physics.Raycast(shootTransform.position, shootTransform.forward,out hit))
                {
                    print("hit");
                    hit.collider.gameObject.GetComponent<StarBehavior>().select();
                }
            }

    }
    }
}