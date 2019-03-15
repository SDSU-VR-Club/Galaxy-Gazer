using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settext : MonoBehaviour
{
    private Text myText;

    public void settextmove(string str , Color txtcolor)
   {
       myText = GetComponentInChildren<Text>();
        myText.color = txtcolor;
        myText.text = str;
       
    }
}
