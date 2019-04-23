
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Valve.VR.InteractionSystem
{
    public class DrawingTool : MonoBehaviour
    {
        Hand myHand;
        public GameObject trailGenerator;
        public GameObject drawingTip;
        public float distance;
        List<GameObject> strokes;
        public GameObject stars;
        // Start is called before the first frame update
        void Start()
        {
            myHand = GetComponent<Hand>();
            strokes = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<Hand>().grabPinchAction.GetLastStateDown(GetComponent<Hand>().handType))
            {
                print("what is going on");
                drawingTip = Instantiate(trailGenerator, transform);
                drawingTip.transform.position = drawingTip.transform.position + drawingTip.transform.forward * distance;
                strokes.Add(drawingTip);
                foreach(TextMeshProUGUI a in stars.GetComponentsInChildren<TextMeshProUGUI>())
                {
                    a.enabled = false;
                }
            }
            if (GetComponent<Hand>().grabPinchAction.GetLastStateUp(GetComponent<Hand>().handType))
            {
                drawingTip.transform.parent = null;
                foreach (TextMeshProUGUI a in stars.GetComponentsInChildren<TextMeshProUGUI>())
                {
                    a.enabled = true;
                }
            }
            if (GetComponent<Hand>().grabGripAction.GetLastStateDown(GetComponent<Hand>().handType)&&strokes.Count>0)
            {
                Destroy(strokes[strokes.Count - 1]);
                strokes.RemoveAt(strokes.Count - 1);
            }
        }
    }
}