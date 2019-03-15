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
        Hand myHand;
        Color green;
        GameObject lastSelectedObject;
        Vector3 FirstAnglePosition;
        Vector3 SecondAnglePosition;
        GameObject head;
        TextMeshProUGUI AngleUI;
        Mesh coneMesh;
        public int DecimalPlaces;
        bool started=false;
        bool measuring = false;
        Vector3[] vertices;
        int[] triangles;
        public MeshRenderer renderer;
        public MeshFilter meshFilter;
        // Use this for initialization
        void Start() {
            myHand = GetComponent<Hand>();
            green = new Color(0, 1, 0);
            head=FindObjectOfType<Camera>().gameObject;
            AngleUI = GetComponentInChildren<TextMeshProUGUI>();
            coneMesh = new Mesh();
            coneMesh.name = "coneMesh";
            triangles = new int[6];
            vertices = new Vector3[3];
            meshFilter.mesh = coneMesh;
            FirstAnglePosition = Vector3.right;
            SecondAnglePosition = Vector3.forward;
            renderer.enabled = false;
        }
       
       
        //Called on trigger press to select a star if pointed one is being pointed at
        void Update() {
            
            if (measuring)
            {
                SecondAnglePosition = transform.forward;
                drawCone();
                float tempAngle = GetAngle(FirstAnglePosition, SecondAnglePosition);
                if (tempAngle != -404)
                    AngleUI.text = (Mathf.Round(tempAngle * Mathf.Pow(10, DecimalPlaces)) / Mathf.Pow(10, DecimalPlaces) + "°");
            }
            RaycastHit hit;

            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                FirstAnglePosition = transform.forward;
                measuring = true;
                renderer.enabled = true;
            }
            if (GetComponent<Hand>().grabPinchAction.GetLastStateUp(GetComponent<Hand>().handType)){
                measuring = false;
                renderer.enabled = false;
            }
           

    }


        float GetAngle(Vector3 first, Vector3 second)
        {
             return Vector3.Angle(first, second);
        }
        void drawCone()
        {
            Matrix4x4 localToWorld = transform.worldToLocalMatrix;


            vertices[0] = localToWorld.MultiplyPoint3x4(transform.position);
            vertices[1] = localToWorld.MultiplyPoint3x4(transform.position+FirstAnglePosition * 1000);
            vertices[2] = localToWorld.MultiplyPoint3x4(transform.position+SecondAnglePosition * 1000);
            coneMesh.vertices = vertices;
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;
            triangles[3] = 2;
            triangles[4] = 1;
            triangles[5] = 0;
            coneMesh.triangles = triangles;

        }
    }
}