using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TEXTSHOW : MonoBehaviour
{

    private GameObject playerObject;

    [SerializeField]
    private GameObject hitmarkerprefab;


    [SerializeField]
    private Color[] colors;

    private  Text text;
    public static int count=1;
    private bool isclicked = false;
    private string temp;

    public void Start()
    {
        playerObject = this.gameObject;
        text = GetComponent<Text>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitthis;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hitthis)) {
                temp = hitthis.collider.name;
                if (temp == playerObject.name && isclicked == false)
                {
                    Hitnow();
                    isclicked = true;
                }
            }
          
        }
    }
    public void Hitnow()
    {
        
        GameObject newMarker = Instantiate(hitmarkerprefab, transform);
        newMarker.SetActive(true);
       newMarker.GetComponent<settext>().settextmove(count.ToString(), colors[Random.Range(0, colors.Length)]);
        newMarker.transform.LookAt(FindObjectOfType<Camera>().transform.position);
        //newMarker.transform.localScale = transform.localScale*0.05f;
        count++;
     }
}

