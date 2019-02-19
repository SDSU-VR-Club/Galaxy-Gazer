using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//see Carter for more info
public class UIManager : MonoBehaviour {
    public GameObject finalUI;
    public TextMeshProUGUI finalText;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //reset event
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    public void nextConstellation(int score)
    {
        //score screen pops up
        
        finalText.SetText(score.ToString());
        finalUI.SetActive(true);
        StartCoroutine(cycleConstellation());
    }
    private IEnumerator cycleConstellation()
    {
        yield return new WaitForSeconds(3);
        finalUI.SetActive(false);

    }
    
}
