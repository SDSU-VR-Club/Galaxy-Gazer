using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueButton : LaserUIButton
{
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Press()
    {
        if (!pressed)
        {
            FindObjectOfType<StarManager>().forceChangeConstellation();
            pressed = true;
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
