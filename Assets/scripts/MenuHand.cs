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

            if (menuButton.GetLastStateDown(GetComponent<Hand>().handType))
            {
                LoadMenuScene();
            }
            
        }
        void LoadMenuScene()
        {
            Destroy(destryOnLoad);
            SceneManager.LoadScene("MenuScene");
        }
    }
}