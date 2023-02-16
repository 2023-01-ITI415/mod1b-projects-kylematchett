using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class BallCounter : MonoBehaviour
{
    public static int blue = 7;
    public static int red = 7;
    public TMP_Text text;
    

    // Update is called once per frame
    void Update()
    {
        text.text = "Red Balls Remaining: "  + red + "\tBlue Balls Remaining: " + blue;
    }
}
