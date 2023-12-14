using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 positionPressMouse;
    private Vector3 positionCurrentOfMouse;
    private bool isRotation = false;
    [SerializeField] private Transform prevBullet;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        positionPressMouse = Vector3.zero;
    }

    void Update()
    {
        Debug.DrawLine(transform.position,transform.position + transform.up * 2, Color.red);
        // Press mouse
        if(Input.GetMouseButtonDown(0)){
            positionPressMouse = getPositionMouse();
            isRotation = true;
        }
        // Hold mouse
        if(isRotation){
            onHoldMouse(); 
        }    
        // Out mouse
        if(Input.GetMouseButtonUp(0)){
            isRotation = false;
            transform.up = Vector3.zero;
            positionPressMouse = Vector3.zero;
            transform.position = prevBullet.position;
        }
    }
    private void onHoldMouse(){
        positionCurrentOfMouse = getPositionMouse();
        Vector3 PointToMouse = new Vector3(
                positionPressMouse.x - positionCurrentOfMouse.x,
                positionPressMouse.y - positionCurrentOfMouse.y,
                positionPressMouse.z - positionCurrentOfMouse.z
        );
        // ##Gioi han PointToMouse.##
        // direction
        transform.up = PointToMouse;
        //force
        Vector3 forceThrow = transform.position - PointToMouse / 50;
        
        transform.position = forceThrow;
    }

    private void AddForce_Throw(){
        rb.AddForce(transform.up);
    }

    // change position of mouse to world game 
    private Vector3 getPositionMouse(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
