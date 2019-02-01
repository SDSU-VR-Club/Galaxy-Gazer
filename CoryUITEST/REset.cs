using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
