using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class nextButton : MonoBehaviour {
    public TextAsset[] constellations;
    int currentConst;
    public TextMeshProUGUI nameDisplay;
    public SpawnStarsCartesian2 starSpawner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void cycle()
    {
        if (currentConst == constellations.Length - 1)
            currentConst = 0;
        else
            currentConst++;
        starSpawner.starData = constellations[currentConst];
        nameDisplay.SetText(constellations[currentConst].name);
    }
}
