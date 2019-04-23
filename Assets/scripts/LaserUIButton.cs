using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserUIButton : MonoBehaviour
{
    [Header("Enable to 'enable objects' when the button is pressed")]
    public bool EnableThings;
    public GameObject[] ThingsToEnable;
    [Header("Enable to 'disable objects' when the button is pressed")]
    public bool DisableThings;
    public GameObject[] ThingsToDisable;
    [Header("Enable to go to a scene when the button is pressed")]
    public bool GoToScene;
    public string NextSceneName;
    [Header("Enable to go to exit program when the button is pressed")]
    public bool ExitProgram;
    public GameObject DestroyOnLoad;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public virtual void Press()
    {
        if (GoToScene)
            goToScene();

        if (EnableThings)
            enable();

        if (DisableThings)
            disable();

        if (ExitProgram)
            Application.Quit();

    }

    public void goToScene()
    {
        if (NextSceneName != null)
        {
            Destroy(DestroyOnLoad);
            SceneManager.LoadScene(NextSceneName);
        }
    }

    public void enable()
    {
        foreach (GameObject EnableObject  in ThingsToEnable)
        {
            EnableObject.SetActive(true);
        }
    }

    public void disable()
    {
        foreach (GameObject EnableObject in ThingsToDisable)
        {
            EnableObject.SetActive(false);
        }
    }


}
