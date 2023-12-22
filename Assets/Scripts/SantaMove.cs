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
    [SerializeField] private GameObject KeyE;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject dieCanvas;
    [SerializeField] private AudioSource audioBG;
    [SerializeField] private AudioClip clipBG;
    [SerializeField] private AudioClip clipLost;

    private float horizontal;
    private float vertical;
    private bool isRight;
    private void Start() {
        Time.timeScale = 1.0f;
        audioBG.clip = clipBG;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Mathf.Round(horizontal)!=0 || Mathf.Round(vertical) != 0){
            anim.SetBool("isThrow",true);
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
            anim.SetBool("isThrow",false);
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Door"){
            KeyE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Door"){
            KeyE.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ghost"){
            other.gameObject.SetActive(false);
            if(ButtonController.getOpenAudio()) audioBG.PlayOneShot(clipLost);
            Time.timeScale = 0.0f;
            dieCanvas.SetActive(true);
            playCanvas.SetActive(false);
        }
    }
}
