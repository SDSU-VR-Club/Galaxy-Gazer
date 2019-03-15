using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerRotate : MonoBehaviour
    {

        public int constToRotateTo;
        public GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = this.gameObject;



        }

        // Update is called once per frame
        void Update()
        {

        }



        public void incrimentRotation()
        {
            ++constToRotateTo;
            if (constToRotateTo == 3)
            {
                constToRotateTo = 0;
            }

        }

        public void playerRotate()
        {

            if (constToRotateTo == 0)
            {
                //player.transform.rotation = Quaternion.Euler(0, -20, 0); //might be better 
                player.transform.eulerAngles = new Vector3(
                    player.transform.eulerAngles.x,
                    player.transform.eulerAngles.y - 20,
                    player.transform.eulerAngles.z
                );
                constToRotateTo++;
            }

            else if (constToRotateTo == 1)
            {
                //player.transform.rotation = Quaternion.Euler(0, 16, 0);
                player.transform.eulerAngles = new Vector3(
                    player.transform.eulerAngles.x,
                    player.transform.eulerAngles.y + 16,
                    player.transform.eulerAngles.z
                );
                constToRotateTo++;
            }

            else
            {
                //player.transform.rotation = Quaternion.Euler(90, 0, 0);
                player.transform.eulerAngles = new Vector3(
                   player.transform.eulerAngles.x + 90,
                   player.transform.eulerAngles.y,
                   player.transform.eulerAngles.z
               );
            }
        }
    }