using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class settext : MonoBehaviour
{
  

    public void settextmove(string str , Color txtcolor)
   {
        var myText = GetComponentInChildren<TextMeshPro>();
        myText.color = txtcolor;
        myText.text = str;
       
    }
}
