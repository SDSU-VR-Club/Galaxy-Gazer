using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Hand))]
    public class UIPointing : MonoBehaviour
    {
        Hand myHand;
        RaycastHit hit;

        void Start()
        {
            myHand = GetComponent<Hand>();
        }

        private void Update()
        {
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.gameObject.tag == "LaserUI")
                    {

                        hit.collider.GetComponent<LaserUIButton>().Press();

                    }
                }
            }
            
        }




    }
}
