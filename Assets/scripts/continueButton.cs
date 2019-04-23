using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueButton : LaserUIButton
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Press()
    {
        FindObjectOfType<StarManager>().forceChangeConstellation();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
