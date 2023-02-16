using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Stick : MonoBehaviour{
    
    [Header("Inscribed")]
    public GameObject StickPrefab;

    [Header("Dynamic")]
    public GameObject CueBall;
    public Vector3 Pos;
    private int Dist = 15;

    private GameObject stick;
    private bool awake = true;
    private float theta;
    private List<GameObject> Balls;
    // Start is called before the first frame update
    void Start()
    {
        CueBall = GameObject.FindGameObjectWithTag("CueBall");
        CueBall.transform.Translate(new Vector3(0,0,0));
        stick = Instantiate( StickPrefab ) as GameObject; 
        stick.transform.position = CueBall.transform.position;
        stick.GetComponent<Rigidbody>().isKinematic = true;
        Balls.Add(CueBall);
        Balls.Add(GameObject.FindGameObjectWithTag("8Ball"));
    }
    void FixedUpdate(){
        //all balls should stop moving before stick can appear
    }

    // Update is called once per frame
    void Update()
    {

        //if ( stick.isKinematic || !awake ){
       //     stick.SetActive(false);
       //     return;
        //}
        //stick.setActive(true);
        Pos = CueBall.transform.position;
        Vector3 mousePos2D = Input.mousePosition;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D );
        //Vector3 mouseDelta = mousePos3D - Pos.position;
        float degrees=0;

        //rotate stick around ball around z axis
        if(Input.GetMouseButton(0)){
            if(mousePos3D.x-Pos.x==0){
                degrees=90;
            }else{
                theta = Convert.ToSingle(Math.Atan((mousePos3D.z-Pos.z)/(mousePos3D.x-Pos.x)));
                degrees = (180f / Convert.ToSingle(Math.PI)) * theta;
            }
            
            
            
            Debug.Log("" + degrees + " stick x: " + stick.transform.position.x + "  stick z: " + stick.transform.position.z +" mouse x: " + mousePos3D.x + "  mouse z: " + mousePos3D.z + "  ball x: " + Pos.x + "  ball z: " + Pos.z);
            
            stick.transform.rotation = Quaternion.Euler(new Vector3(90,0,degrees +90));
            float z = Convert.ToSingle(Math.Sin(theta) * Dist);
            
            float x = Convert.ToSingle(Math.Cos(theta) * Dist);
            if(mousePos3D.x<=Pos.x){
                x *=-1;
                z*=-1;
            }
            
            
            stick.transform.position = new Vector3(CueBall.transform.position.x + x, stick.transform.position.y, CueBall.transform.position.z + z);
            
        }else{
            
            if(mousePos3D.z-Pos.z==0){
                stick.transform.position = new Vector3(mousePos3D.x, stick.transform.position.y,stick.transform.position.z);
                Debug.Log("here");
            }else{
                float m = (mousePos3D.x-Pos.x)/(mousePos3D.z-Pos.z);
                float m1 = -1/m;
                float x1 = Pos.x, x2 = mousePos3D.x, z1 = Pos.z, z2 = mousePos3D.z;
                float stickX = (x2/m + z2 - z1)/(2*m);
                float stickZ = m*(stickX-x1)+z1;
                stick.transform.position = new Vector3(stickX,stick.transform.position.y,stickZ);
            }
       }


    }



}
