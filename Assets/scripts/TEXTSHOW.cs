using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TEXTSHOW : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private GameObject hitmarkerprefab;


    [SerializeField]
    private Color[] colors;

    private  Text text;
    public int count;
    private bool isclicked = false;
    private string temp;

    public void Start()
    {
        text = GetComponent<Text>();
        count = 0;
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
            count++;
        }
    }
    public void Hitnow()
    {
        GameObject newMarker = Instantiate(hitmarkerprefab, (playerObject.transform.position + new Vector3(0,1.3f,0)), Quaternion.identity);
        newMarker.SetActive(true);
       newMarker.GetComponent<settext>().settextmove(count.ToString(), colors[Random.Range(0, colors.Length)]);

     }
}

