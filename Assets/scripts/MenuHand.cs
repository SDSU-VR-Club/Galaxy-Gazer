using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using Valve.VR;
namespace Valve.VR.InteractionSystem
{
    
    public class MenuHand : MonoBehaviour
    {
        public SteamVR_Action_Boolean menuButton;
        public GameObject destryOnLoad;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (menuButton.GetLastStateDown(GetComponent<Hand>().handType)||Input.GetKeyDown(KeyCode.M))
            {
                Destroy(destryOnLoad);
                LoadMenuScene();
            }
            if ( Input.GetKeyDown(KeyCode.Alpha1))
            {
                Destroy(destryOnLoad);
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Destroy(destryOnLoad);
                SceneManager.LoadScene(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Destroy(destryOnLoad);
                SceneManager.LoadScene(2);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(destryOnLoad);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }

        }
        void LoadMenuScene()
        {
            Destroy(destryOnLoad);
            SceneManager.LoadScene("MenuScene");
        }
    }
}