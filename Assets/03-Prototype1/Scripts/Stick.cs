using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Stick : MonoBehaviour{
    
    [Header("Inscribed")]
    public GameObject StickPrefab;

    [Header("Dynamic")]
    private GameObject CueBall;
    private Vector3 Pos;
    private float Dist = 11f;
    private float Power = 0;

    private GameObject stick;
    //private bool awake = true;
    private float theta;
    //private List<GameObject> Balls;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        CueBall = GameObject.FindGameObjectWithTag("CueBall");
        CueBall.transform.Translate(new Vector3(0,0,0));
        stick = Instantiate( StickPrefab ) as GameObject; 
        stick.transform.position = new Vector3(CueBall.transform.position.x,6,CueBall.transform.position.z);;
        stick.GetComponent<Rigidbody>().isKinematic = true;
        rb = CueBall.GetComponent<Rigidbody>();
       // Balls.Add(CueBall);
        //Balls.Add(GameObject.FindGameObjectWithTag("8Ball"));
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

        if(rb.velocity.magnitude>0)
            stick.SetActive(false);
        else
            stick.SetActive(true);


        //rotate stick around ball around z axis
        if(!Input.GetMouseButtonDown(0)){
            if(mousePos3D.x-Pos.x==0){
                degrees=90;
            }else{
                theta = Convert.ToSingle(Math.Atan((mousePos3D.z-Pos.z)/(mousePos3D.x-Pos.x)));
                degrees = (180f / Convert.ToSingle(Math.PI)) * theta;
            }
            
            
            
            //Debug.Log("" + degrees + " stick x: " + stick.transform.position.x + "  stick z: " + stick.transform.position.z +" mouse x: " + mousePos3D.x + "  mouse z: " + mousePos3D.z + "  ball x: " + Pos.x + "  ball z: " + Pos.z);
            
            stick.transform.rotation = Quaternion.Euler(new Vector3(90,0,degrees +90));
            if(  (mousePos3D.z-Pos.z) * (mousePos3D.z-Pos.z) +  (mousePos3D.x-Pos.x) * (mousePos3D.x-Pos.x) < Dist*Dist ){
                float z = Convert.ToSingle(Math.Sin(theta) * Dist);
                
                float x = Convert.ToSingle(Math.Cos(theta) * Dist);
                if(mousePos3D.x<=Pos.x){
                    x *=-1;
                    z*=-1;
                }
                
                
                stick.transform.position = new Vector3(CueBall.transform.position.x + x, stick.transform.position.y, CueBall.transform.position.z + z);
            }else{
                stick.transform.position = new Vector3(mousePos3D.x, stick.transform.position.y, mousePos3D.z);

            }
            Power = (stick.transform.position.x - Pos.x) * (stick.transform.position.x - Pos.x) + (stick.transform.position.z - Pos.z) * (stick.transform.position.z - Pos.z);
            Power = Power*0.2f;
        }else{

            float z = Convert.ToSingle(Math.Sin(theta) * 1.15);
                
            float x = Convert.ToSingle(Math.Cos(theta) * 1.15);
            if(stick.transform.position.x<=Pos.x){
                x *=-1;
                z*=-1;
            }
            stick.transform.position = new Vector3(Pos.x + x, stick.transform.position.y, Pos.z + z);
            rb.velocity = new Vector3(-x*Power,0,-z*Power);
            
       }
            

    }



}
