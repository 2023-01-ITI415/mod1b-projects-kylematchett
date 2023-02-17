using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    

    private Rigidbody rb;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
        
    }


    void Update()
    {

        
        if (this.transform.position.y <-5){
            this.transform.position = new Vector3(0,-2,0);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            if (this.tag == "Red")
                BallCounter.red--;
            else if (this.tag == "Blue")
                BallCounter.blue--;
            else if (this.tag == "8Ball")
                BallCounter.black--;

        }else if( this.transform.position.y >01.625){
            this.transform.position = new Vector3(this.transform.position.x,01.625f, this.transform.position.z);
        
        }else if(rb.velocity.magnitude < 0.1 && rb.velocity.magnitude !=0){
            rb.velocity = new Vector3(0f,0f,0f);
            rb.angularVelocity = new Vector3(0f,0f,0f);
        }else if(rb.velocity.magnitude < 1.5){
            rb.velocity = rb.velocity * 0.8f;

        }
    }
}
