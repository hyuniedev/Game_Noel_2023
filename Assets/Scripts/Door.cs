using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite doorOpen;
    [SerializeField] private Sprite doorClose;
    [SerializeField] private GameObject KeyE;
    private bool stateDoor;
    private void Start() {
        KeyE.SetActive(false);
        stateDoor = false;
    }
    private void Update() {
        Debug.Log(stateDoor);
        if(stateDoor){
            transform.GetComponent<SpriteRenderer>().sprite = doorOpen;
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else{
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<SpriteRenderer>().sprite = doorClose;
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            KeyE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                stateDoor = !stateDoor;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            KeyE.SetActive(true);
        }
    }
    // private void OnTriggerStay2D(Collider2D other) {
    //     KeyE.SetActive(true);
    //     if(other.gameObject.tag == "Player"){
    //         if(Input.GetKeyDown(KeyCode.E)){
    //             stateDoor = !stateDoor;
    //         }
    //     }
    // }
    // private void OnTriggerExit2D(Collider2D other) {
    //     if(other.gameObject.tag == "Player"){
    //         KeyE.SetActive(true);
    //     }
    // }
}
