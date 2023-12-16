using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject gift;
    [SerializeField] private Transform transformRepawn;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float forceThrow = 100f;
    private Vector3 imaMouse;
    private Vector3 tenClickMouse;
    private bool clickDekiru = true;

    private void Start() {
        resetStaticGift();
    }
    private void Update() {
        if(clickDekiru){
            checkClickOnMouse();
        }
    }
    private void checkClickOnMouse(){
        // start click
        if(Input.GetMouseButtonDown(0)){
            tenClickMouse = getPositionMouse();
        }
        // on click
        if(Input.GetMouseButton(0)){
            gift.transform.up = -1 * getVectorMouse();
            imaMouse = getPositionMouse();
            Debug.DrawLine(gift.transform.position,gift.transform.up * 2 + gift.transform.position,Color.magenta);
        }
        // end click
        if(Input.GetMouseButtonUp(0)){
            clickDekiru = false;
            AddForce();
            Invoke(nameof(resetStaticGift), 2.0f);
        }
    }

        private void resetStaticGift(){
        gift.transform.position = transformRepawn.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
        tenClickMouse = Vector3.zero;
        imaMouse = Vector3.zero;
        clickDekiru = true;
    }
    private Vector3 getVectorMouse(){
        return imaMouse - tenClickMouse;
    }
    private void AddForce(){
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(gift.transform.up.normalized * Mathf.Abs(getPositionMouse().magnitude) * forceThrow);
    }
    private Vector3 getPositionMouse(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
