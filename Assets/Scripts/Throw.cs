using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour
{
    [SerializeField] private Animator animSanta;
    [SerializeField] private GameObject gift;
    [SerializeField] private Transform transformRepawn;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float forceThrow = 100f;
    private Vector3 imaMouse;
    private Vector3 tenClickMouse;
    public bool clickDekiru = true;

    private void Start() {
        resetStaticGift();
        gift.SetActive(false);
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
            imaMouse = getPositionMouse();
        }
        // end click
        if(Input.GetMouseButtonUp(0)){
            animSanta.SetBool("isThrow",true);
            clickDekiru = false;
            Invoke(nameof(AddForce),0.5f);
            Invoke(nameof(resetStaticGift), 2.5f);
        }
    }
    private void resetStaticGift(){
        gift.transform.position = transformRepawn.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
        tenClickMouse = Vector3.zero;
        imaMouse = Vector3.zero;
        clickDekiru = true;
        gift.SetActive(false);
    }
    private void AddForce(){
        gift.SetActive(true);
        animSanta.SetBool("isThrow",false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(getVectorMouse().normalized * -1 * Mathf.Abs(getVectorMouse().magnitude) * forceThrow);
    }
    private Vector3 getVectorMouse(){
        return imaMouse - tenClickMouse; 
    }
    private Vector3 getPositionMouse(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public double getCurForce(){
        return getVectorMouse().magnitude;
    }
}
