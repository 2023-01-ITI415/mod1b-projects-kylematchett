using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;    

public class BallCounter : MonoBehaviour
{
    public static int blue = 7;
    public static int red = 7;
    public static int black = 1;
    public TMP_Text text;
    
    void FixedUpdate()
    {
        if( (blue ==0 && black == 0)|| (red==0 && black == 0) || black ==0)
        {
            blue = 7;
            red = 7;
            black = 1;
            SceneManager.LoadScene("Main-Prototype 1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Red Balls Remaining: "  + red + "\tBlue Balls Remaining: " + blue;
    }
}
