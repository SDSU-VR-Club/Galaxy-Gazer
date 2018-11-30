using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Flare))]
public class flareScaler : MonoBehaviour {
    public float Brightness;
    public float minimumBrightness;
    public float scaleRate;
    public Transform camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<LensFlare>().brightness = Brightness / (scaleRate*Vector3.Distance(transform.position, camera.transform.position));
        if (GetComponent<LensFlare>().brightness < minimumBrightness)
            GetComponent<LensFlare>().brightness = minimumBrightness;





    }
}
