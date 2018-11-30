using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

public class spacecontrols : MonoBehaviour
{
    public float speed;
    public Vector3 Ldirection;
    public Vector3 Rdirection;

    public SteamVR_Action_Vector2 touchPadAction;
    public GameObject left;
    public GameObject right;
    
    void Start()
    {

    }


    void Update()
    {
        Rdirection = right.transform.rotation * Vector3.forward;
        Ldirection = left.transform.rotation * Vector3.forward;

        Vector2 LtouchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.LeftHand);
        Vector2 RtouchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (LtouchpadValue.y != 0)
        {
            transform.position += Ldirection * speed * LtouchpadValue.y;
            print("Lyo");
        }

        if (RtouchpadValue.y != 0)
        {
            transform.position += Rdirection * speed * RtouchpadValue.y;
            print("Ryo");
        }

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("tele");
        }
    }
}