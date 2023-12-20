using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject TheDoor;
    [SerializeField] private Sprite spriteDoorOpen;
    [SerializeField] private Sprite spriteDoorClose;
    [SerializeField] private GameObject ColliderDoor;
    private bool keyEActive;
    private void Start() {
        ColliderDoor.SetActive(false);
        keyEActive = false;
    }
    private void Update() {
        if(keyEActive){
            if(Input.GetKeyDown(KeyCode.E)){
                ColliderDoor.SetActive(false);
                TheDoor.GetComponent<SpriteRenderer>().sprite = spriteDoorOpen;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            keyEActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            keyEActive = false;
            TheDoor.GetComponent<SpriteRenderer>().sprite = spriteDoorClose;
            ColliderDoor.SetActive(true);
        }
    }
}