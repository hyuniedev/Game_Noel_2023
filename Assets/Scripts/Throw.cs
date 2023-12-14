using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Vector3 positionPressMouse;
    private Vector3 positionCurrentOfMouse;
    private bool isRotation = false;
    private float x = 15f ,y = 5f;
    [SerializeField] private Transform prevBullet;
    // Start is called before the first frame update
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
        // direction
        transform.up = PointToMouse;
        //force
        //Vector3 force = PointToMouse / 50;
        //transform.position = new Vector3(transform.position.x - force.x, transform.position.y - force.y, transform.position.z - force.z);
        Vector3 forceThrow = transform.position - PointToMouse / 50;
        Debug.Log(forceThrow);
        if(Mathf.Abs(forceThrow.x) < x && Mathf.Abs(forceThrow.y) < y){
            transform.position = forceThrow;
        }else{
            Debug.Log("X or y qua gioi han roi");
            if(Mathf.Abs(forceThrow.x) > x){
                forceThrow.x = x;
                transform.position = forceThrow;
            }
            if(Mathf.Abs(forceThrow.y) > y){
                forceThrow.y = y;
                transform.position = forceThrow;
            }
        }
    }
    // change position of mouse to world game 
    private Vector3 getPositionMouse(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
