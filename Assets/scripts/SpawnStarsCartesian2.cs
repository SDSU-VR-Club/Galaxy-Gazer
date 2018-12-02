﻿using UnityEngine;
using System.Collections;

public class SpawnStarsCartesian2 : MonoBehaviour {

    [Header("CSV file of star data")]
    public TextAsset starData;
    [Space(10)]

    [Header("Column of the star's name")]
    public int NameColumn;
    [Space(10)]

    [Header("Column of the XYZ positions")]
    public int Xcolumn;
    public int Ycolumn;
    public int Zcolumn;
    [Space(10)]

    [Header("Column of the star's diameter")]
    public int DiamaterColumn;
    [Space(10)]

    [Header("Column of the star's color")]
    public bool HexadecimalColor;
    public int RcolorColumn;
    public int GcolorColumn;
    public int BcolorColumn;
    [Space(10)]

    [Header("Star prefab")]
    public GameObject DefaultStar;
    string[] data;

	void Start ()
	{

        data = starData.text.Split(new char[] { '\n' });

        for(int i = 1; i < data.Length; i++)
        {
            float x = 0;
            float y = 0;
            float z = 0;

            float d = 0;

            float r = 0;
            float g = 0;
            float b = 0;
            Color hexcolor;

            string[] row = data[i].Split(new char[] { ',' });
            //makestar
            GameObject tempStar = Instantiate(DefaultStar);
            //make star child
            tempStar.transform.parent = transform;
            //name star
            tempStar.name = row[NameColumn - 1];
            //star position
            float.TryParse(row[Xcolumn - 1], out x);
            float.TryParse(row[Ycolumn - 1], out y);
            float.TryParse(row[Zcolumn - 1], out z);
            tempStar.transform.position = new Vector3(x,y,z);
            //star diameter
            float.TryParse(row[DiamaterColumn - 1], out d);
            tempStar.transform.localScale = new Vector3(d, d, d);
            //star color
            Material starMaterial = new Material(Shader.Find("Standard"));
            tempStar.GetComponent<Renderer>().material = starMaterial;
            if (HexadecimalColor)
            {
                ColorUtility.TryParseHtmlString(row[RcolorColumn - 1], out hexcolor);
                starMaterial.SetColor("_Color", hexcolor);
            }
            else
            {
                float.TryParse(row[RcolorColumn - 1], out r);
                float.TryParse(row[GcolorColumn - 1], out g);
                float.TryParse(row[BcolorColumn - 1], out b);
                starMaterial.SetColor("_Color", new Color(r, g, b));
            }


        }
	}
	

	void Update ()
	{
		
	}
}