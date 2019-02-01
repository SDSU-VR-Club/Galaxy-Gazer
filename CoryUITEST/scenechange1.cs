using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenechange1 : MonoBehaviour {

	public void changeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
	
	
}
