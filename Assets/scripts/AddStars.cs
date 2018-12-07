using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStars : MonoBehaviour
{

    public GameObject Addstars;
    GameObject AddStarsClone;

    void Update()
    {
        if(Input.GetKeyDown("d"))
        AddStarsClone = Instantiate(Addstars,transform.position,Quaternion.identity) as GameObject;
        
    }

}
