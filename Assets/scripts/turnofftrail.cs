using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class turnofftrail : MonoBehaviour
    {
        Hand myHand;
        // Use this for initialization
        void Start()
        {
            myHand = GetComponent<Hand>();
        }

        // Update is called once per frame
        bool count = true;
        void Update()
        {

            if (count  && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)|| GetComponent<Hand>().grabGripAction.GetLastStateDown(GetComponent<Hand>().handType)))
            {
              
                foreach (TrailRenderer a in FindObjectsOfType<TrailRenderer>())
                    a.enabled = false;
                count = false;
            }
            else if (!count  && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)|| GetComponent<Hand>().grabGripAction.GetLastStateDown(GetComponent<Hand>().handType)))
            {
                foreach (TrailRenderer a in FindObjectsOfType<TrailRenderer>())
                    a.enabled = true;
                count = true;
            }
        }
    }
}