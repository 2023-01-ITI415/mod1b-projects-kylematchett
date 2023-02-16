using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool rotateMode;
    private Vector3 previousPosition;
    public Transform cueBall;
    private float distanceToTarget = 10;
    private Camera cam;

    void Start(){
        cam = Camera.main;
    }

    void Update(){
        previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = previousPosition - newPosition;
        
        float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
        float rotationAroundXAxis = direction.y * 180; // camera moves vertically
        
        cam.transform.position = cueBall.position;
        
        cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
        
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        
        previousPosition = newPosition;
    }
}
