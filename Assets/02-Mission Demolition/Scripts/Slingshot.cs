using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    [Header("Inscribed")]
    public GameObject projectilePrefab;
    public float velocityMult = 10f;
    [Header("Dynamic")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake() {
        Transform launchPointTrans =
        transform.Find("LaunchPoint"); // a
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive( false );
        launchPos = launchPointTrans.position;
    // b
    }
    
    void OnMouseEnter() {
    //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive( true );
    // b
    }
    
    void OnMouseExit() {
    //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive( false );
    // b
    }

    void OnMouseDown() {
        aimingMode = true;
        projectile = Instantiate( projectilePrefab ) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }


    void Update() {
        if (!aimingMode) return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D );
        Vector3 mouseDelta = mousePos3D -launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        // Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if ( Input.GetMouseButtonUp(0) ) { // This 0 is a
            if ( Input.GetMouseButtonUp(0) ) { // This 0 is a zero, not an o // e
            // The mouse has been released
            aimingMode = false;
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.isKinematic = false;
            // f
            projRB.collisionDetectionMode =  CollisionDetectionMode.Continuous;
            projRB.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
            // g
            }
        }
    }

}
