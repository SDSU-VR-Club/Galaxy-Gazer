using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//carter code 
//used on stars to make them appear dimmer further away
public class newFlareScaler : MonoBehaviour {
    //base size of the star
    private float Size;
    //flare component
    public LensFlare Flare;
    public Transform mainCam;
    //used for initialization
    bool first = true;
    //determines the rate of fading with distance
    public float dampening;
    //distance cant reduce a flare beneath this size
    public float minimumBrightness;
    void Start()
    {

        if (mainCam == null)
            mainCam = Camera.main.transform;

        if (Flare == null)
            Flare = GetComponent<LensFlare>();

        if (Flare == null)
        {
            Debug.LogWarning("No LensFlare on " + name + ", destroying.", this);
            Destroy(this);
            return;
        }

        
    }

    void Update()
    {
        //initialize size as flare brighness on first frame
        if (first)
        {
            Size = Flare.brightness;
            first = false;
        }
        //float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, mainCam.position));

        //scale brightness with distance
        float ratio = Mathf.Pow(Vector3.Distance(transform.position, mainCam.position),2*dampening);
        Flare.brightness = Size / ratio;
        //enforce minimum
        if (Flare.brightness < minimumBrightness)
            Flare.brightness = minimumBrightness;
    }
}