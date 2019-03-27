using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrbitTracker : MonoBehaviour
{
    public GameObject textObject;

    private Vector3 previousPos;
    private float angle, totalAngle;
    private int days, years, months;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        previousPos = Vector3.zero;
        days = years = months = 0;
        angle = totalAngle = 0f;
        text = textObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        angle = Vector3.Angle(previousPos, gameObject.transform.position);
        totalAngle += Mathf.Abs(angle);

        //months & years
        months = Mathf.RoundToInt((totalAngle / 360) * 12);
        if (months >= 12)
        {
            totalAngle -= 360;
            years++;
            months = 0;
        }

        text.SetText("Time passed:\n{0} months, {1} years", months, years);

        // days version


        //days = Mathf.RoundToInt((totalAngle / 360) * 365);
        //if (days >= 365)
        //{
        //    totalAngle -= 360;
        //    years++;
        //    days = 0;
        //}

        //text.SetText("Time passed:\n{0} days, {1} years", days, years);

        //Debug.Log(days + " days, " + years + " years");

        previousPos = gameObject.transform.position;
    }
}
