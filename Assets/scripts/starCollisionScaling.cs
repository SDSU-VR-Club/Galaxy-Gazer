using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script made by Sam
public class starCollisionScaling : MonoBehaviour {

    Transform star;
    Transform player;
    SphereCollider starcollider;
    public float mult;
    public int mindist;

    //Vector3 player;

    private void Awake()
    {
        star = this.transform;
        player = FindObjectOfType<Camera>().transform;
        float thisdistance = distance();
        starcollider = star.GetComponent<SphereCollider>();

        float colliderincrease = thisdistance * mult;

        if (thisdistance > mindist)
        {
            //Debug.Log(star.name + " is to far away! The radius was " + starcollider.radius + "and it needs to " + (starcollider.radius + colliderincrease));
            starcollider.radius += colliderincrease;
           // Debug.Log("The radius of " + star.name + " is now" + starcollider.radius);
        }
        else
        {
            ;// Debug.Log(star.name + " is close enough.No collider increase is needed.");
        }
    }

    public float distance(){
        return Vector3.Distance(star.position, player.position);
    }
}

