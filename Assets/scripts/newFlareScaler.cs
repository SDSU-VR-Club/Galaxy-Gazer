using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//carter code 
//used on stars to make them appear dimmer further away
public class newFlareScaler : MonoBehaviour {
    //size multiplier on the star
    //flare component
    Transform mainCam;
    //used for initialization
    bool first = true;
    //determines the rate of fading with distance
    public float dampening;
    //distance cant reduce a flare beneath this size
    public float minimumBrightness;
    void Start()
    {

        if (mainCam == null)
            mainCam = FindObjectOfType<Camera>().transform;

   
        
    }

    void Update()
    {
        transform.LookAt(mainCam.position);
        ////initialize size as flare brighness on first frame
        //if (first)
        //{
        //    Size = Flare.brightness;
        //    first = false;
        //}
        ////float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, mainCam.position));

        ////scale brightness with distance
        //float ratio = Mathf.Pow(Vector3.Distance(transform.position, mainCam.position),2*dampening);
        //Flare.brightness = Size / ratio;
        ////enforce minimum
        //if (Flare.brightness < minimumBrightness)
        //    Flare.brightness = minimumBrightness;
    }
}