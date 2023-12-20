using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SantaMove : MonoBehaviour
{
    [SerializeField] private GameObject imgSanta;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speedMove = 25f;
    private float horizontal;
    private float vertical;
    private bool isRight;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Mathf.Round(horizontal)!=0 || Mathf.Round(vertical) != 0){
            float x = horizontal, y = vertical;
            if(Mathf.Abs(Mathf.Round(x)) == Mathf.Abs(Mathf.Round(y))){
                x = 1/Mathf.Sqrt(2) * horizontal;
                y = 1/Mathf.Sqrt(2) * vertical;
            }
            rb.velocity = new Vector3(x * speedMove, y * speedMove, 0);
            if(horizontal>0) isRight = true;
            else if(horizontal<0) isRight = false;
            imgSanta.transform.rotation = Quaternion.Euler(new Vector3(0,isRight?0:180,0));
        }else{
            rb.velocity = Vector3.zero;
        }
    }
    private void MoveSanta(){
        
    }
    private Vector3 getPositionMouse(){
        return Camera.main.WorldToScreenPoint(Input.mousePosition);
    }
}
