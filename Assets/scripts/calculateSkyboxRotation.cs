using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculateSkyboxRotation : MonoBehaviour
{
    Vector3 skyF;
    Vector3 skyU;
    // Start is called before the first frame update
    void Start()
    {
        skyF = new Vector3(-0.868f, 0.198f, 0.456f);
        skyU = new Vector3(-0.055f, 0.873f, -0.484f);
        transform.localRotation = Quaternion.LookRotation(skyF, skyU);
        print(transform.localEulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
