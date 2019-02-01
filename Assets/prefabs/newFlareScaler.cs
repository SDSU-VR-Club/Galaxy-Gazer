using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newFlareScaler : MonoBehaviour {
    private float Size;
    public LensFlare Flare;
    public Transform mainCam;
    bool first = true;
    public float dampening;
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
        if (first)
        {
            Size = Flare.brightness;
            first = false;
        }
        //float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, mainCam.position));
        float ratio = Mathf.Pow(Vector3.Distance(transform.position, mainCam.position),2*dampening);
        Flare.brightness = Size / ratio;
        if (Flare.brightness < minimumBrightness)
            Flare.brightness = minimumBrightness;
    }
}