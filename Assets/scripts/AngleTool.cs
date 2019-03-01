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
            StartCoroutine(begin());
            head=FindObjectOfType<Camera>().gameObject;
            AngleUI = GetComponentInChildren<TextMeshProUGUI>();
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
                if (Physics.Raycast(shootTransform.position, shootTransform.forward, out hit))
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

                SelectTwo();
                float tempAngle = GetAngle(FirstAnglePosition, SecondAnglePosition);
                if (tempAngle != -404)
                AngleUI.text = (Mathf.Round(tempAngle*Mathf.Pow(10,DecimalPlaces)) / Mathf.Pow(10, DecimalPlaces) + "°");

                lastSelectedObject.GetComponent<StarBehavior>().select();
                //if (Physics.Raycast(shootTransform.position, shootTransform.forward, out hit))
                //{
                //    if (hit.collider.gameObject.GetComponent<StarBehavior>() != null)
                //    {
                //        hit.collider.gameObject.GetComponent<StarBehavior>().select();
                //    }
                //}
            }
           

    }

        void SelectTwo()
        {
            if (FirstAnglePosition != lastSelectedObject.transform.position)
            {
                SecondAnglePosition = FirstAnglePosition;
                FirstAnglePosition = transform.forward;

                //print("---------");
                //print(FirstAnglePosition);
                //print(SecondAnglePosition);
            }
            else
            {
                //print("---------");
                //print("already selected");
            }

        }

        float GetAngle(Vector3 first, Vector3 second)
        {
             return Vector3.Angle(first, second);
        }

    }
}