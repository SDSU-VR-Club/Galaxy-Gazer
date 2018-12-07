using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour {
    public GameObject finalUI;
    public TextMeshProUGUI finalText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    public void gameOver(int score)
    {
        finalUI.SetActive(true);
        finalText.SetText(score.ToString());
    }
}
