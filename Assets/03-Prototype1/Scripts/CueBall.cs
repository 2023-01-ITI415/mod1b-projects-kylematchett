using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
   

    private Rigidbody rb;
    void Start(){
        rb = this.GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        
        if(this.transform.position.y <=-5){
            this.transform.position = new Vector3(0f,1.625f,0f);
            rb.velocity = new Vector3(0f,0f,0f);
            rb.angularVelocity = new Vector3(0f,0f,0f);
        }
        else if( this.transform.position.y >1.625){
            this.transform.position = new Vector3(this.transform.position.x,1.625f, this.transform.position.z);
        
        }else if(rb.velocity.magnitude < 0.1 && rb.velocity.magnitude !=0){
            rb.velocity = new Vector3(0f,0f,0f);
            rb.angularVelocity = new Vector3(0f,0f,0f);
        }else if(rb.velocity.magnitude < 1.5){
            rb.velocity = rb.velocity * 0.9f;

        }
        

    }
}
