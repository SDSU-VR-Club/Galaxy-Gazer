﻿using UnityEngine;
using System.Collections;

public class AdvancedSpawnStarsPolar : MonoBehaviour {

    public GameObject STARSHOOTER;
    public TextAsset StarList;
    public GameObject DefaultStar;
    public string[] data;

	void Start ()
	{
        TextAsset starData = StarList;

        data = starData.text.Split(new char[] { '\n' });
        
        for(int i = 1; i < data.Length -1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            float longitude = 0;
            float latitude = 0;
            float distance = 0;
            float diameter = 0;
            float.TryParse(row[2], out longitude);
            float.TryParse(row[3], out latitude);
            float.TryParse(row[4], out distance);
            float.TryParse(row[5], out diameter);
            GameObject tempStar = Instantiate(DefaultStar, STARSHOOTER.transform);
            STARSHOOTER.transform.eulerAngles = new Vector3(0, longitude*-6.5f, latitude);
            tempStar.transform.localPosition = new Vector3(distance, 0, 0);
            tempStar.transform.parent = transform;
            tempStar.transform.localScale = new Vector3(10, 10, 10);
            Material starMaterial = new Material(Shader.Find("Standard"));
            tempStar.GetComponent<Renderer>().material = starMaterial;
            starMaterial.SetColor("_Color", new Color(1, 1, 1));
            tempStar.name = row[1];

            {
                /*
                float x = 0;
                float y = 0;
                float z = 0;

                float d = 0;

                float r = 0;
                float g = 0;
                float b = 0;

                string[] row = data[i].Split(new char[] { ',' });
                //makestar
                GameObject tempStar = Instantiate(DefaultStar);
                //make star child
                tempStar.transform.parent = transform;
                //name star
                tempStar.name = row[1];
                //star position
                float.TryParse(row[2], out x);
                float.TryParse(row[3], out y);
                float.TryParse(row[4], out z);
                tempStar.transform.position = new Vector3(x,y,z);
                //star diameter
                float.TryParse(row[5], out d);
                tempStar.transform.localScale = new Vector3(d, d, d);
                //star color
                float.TryParse(row[6], out r);
                float.TryParse(row[7], out g);
                float.TryParse(row[8], out b);
                Material starMaterial = new Material(Shader.Find("Standard"));
                tempStar.GetComponent<Renderer>().material = starMaterial;
                starMaterial.SetColor("_Color", new Color(r, g, b));
                */
            }
        }
        
	}
	

	void Update ()
	{
		
	}
}