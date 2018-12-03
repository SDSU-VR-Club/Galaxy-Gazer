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

        // Update is called once per frame
        void Update() {
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                RaycastHit hit;
                if (Physics.Raycast(shootTransform.position, shootTransform.forward,out hit))
                {
                    print("hit");
                    hit.collider.gameObject.GetComponent<LensFlare>().color = green;
                }
            }

    }
    }
}