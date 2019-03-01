using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//see Carter for more info
namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Hand))]
    public class AngleTool : MonoBehaviour {
        //where the hand beam points from
        public Transform shootTransform;
        Hand myHand;
        Color green;
        GameObject lastSelectedObject;
        Vector3 FirstAnglePosition;
        Vector3 SecondAnglePosition;
        GameObject head;
        TextMeshProUGUI AngleUI;
        
        public int DecimalPlaces;
        bool started=false;
        // Use this for initialization
        void Start() {
            myHand = GetComponent<Hand>();
            green = new Color(0, 1, 0);
            head=FindObjectOfType<Camera>().gameObject;
            AngleUI = GetComponentInChildren<TextMeshProUGUI>();
        }
       
       
        //Called on trigger press to select a star if pointed one is being pointed at
        void Update() {
            RaycastHit hit;
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {

                if (FirstAnglePosition == null)
                {
                    FirstAnglePosition = shootTransform.forward;
                }
                else
                {
                    SecondAnglePosition = FirstAnglePosition;
                    FirstAnglePosition = shootTransform.forward;
                    float tempAngle = GetAngle(FirstAnglePosition, SecondAnglePosition);
                    if (tempAngle != -404)
                        AngleUI.text = (Mathf.Round(tempAngle * Mathf.Pow(10, DecimalPlaces)) / Mathf.Pow(10, DecimalPlaces) + "°");

                }
            }
           

    }


        float GetAngle(Vector3 first, Vector3 second)
        {
             return Vector3.Angle(first, second);
        }

    }
}