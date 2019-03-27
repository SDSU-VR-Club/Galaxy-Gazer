using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTracker : MonoBehaviour
{
    public GameObject textObject;

    private Vector3 previousPos;
    private float angle, totalAngle;
    private int days, years;

    // Start is called before the first frame update
    void Start()
    {
        previousPos = Vector3.zero;
        days = years = 0;
        angle = totalAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Vector3.Angle(previousPos, gameObject.transform.position);
        totalAngle += Mathf.Abs(angle);

        if(totalAngle > 360f)
        {
            totalAngle -= 360;
            years++;
            days -= 365;
        }

        days = Mathf.RoundToInt((totalAngle / 360) * 365);

        textObject.GetComponent<Text>().setText("Time passed:\n{0} days, {1} years", days, years);
        Debug.Log(days + " days, " + years + " years");
        previousPos = gameObject.transform.position;
    }
}
