using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class turnofftrail : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        int count = 0;
        void Update()
        {

            if (count == 0 && Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                GetComponent<TrailRenderer>().enabled = false;
                count = 1;
            }
            else if (count == 1 && Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                GetComponent<TrailRenderer>().enabled = true;
                count = 0;
            }
        }
    }
}