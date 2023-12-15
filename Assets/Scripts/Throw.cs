using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 positionPressMouse;
    private Vector3 positionCurrentOfMouse;
    private bool isRotation = false;
    [SerializeField] private Transform prevBullet;
    [SerializeField] private int forceBall = 100;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        positionPressMouse = Vector3.zero;
    }

    void Update()
    {
        Test();
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
            AddForce_Throw();
            transform.up = Vector3.zero;
            positionPressMouse = Vector3.zero;
            transform.position = prevBullet.position;
        }
    }
    private void Test(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
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
        Vector3 forceThrow = transform.position - PointToMouse / 100;
        
        transform.position = forceThrow;
    }

    private void AddForce_Throw(){
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(transform.up * transform.position.magnitude * forceBall);
    }

    // change position of mouse to world game 
    private Vector3 getPositionMouse(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Respawn"){
            transform.position = prevBullet.position;
            rb.velocity = Vector3.zero;
            transform.up = Vector3.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
