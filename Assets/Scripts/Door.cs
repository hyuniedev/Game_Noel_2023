using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject TheDoor;
    [SerializeField] private Sprite spriteDoorOpen;
    [SerializeField] private Sprite spriteDoorClose;
    [SerializeField] private GameObject ColliderDoor;
    [SerializeField] private KeyController key;
    [SerializeField] private bool canCoChia = false;
    [SerializeField] private AudioSource audioDoor;
    [SerializeField] private AudioClip clipOpenDoor;
    [SerializeField] private AudioClip clipNotKey;
    private bool keyEActive;
    private void Start() {
        ColliderDoor.SetActive(true);
        audioDoor.clip = clipOpenDoor;
        keyEActive = false;
    }
    private void Update() {
        if(keyEActive){
            if(Input.GetKeyDown(KeyCode.E) && !canCoChia){
                ColliderDoor.SetActive(false);
                TheDoor.GetComponent<SpriteRenderer>().sprite = spriteDoorOpen;
                audioDoor.clip = clipOpenDoor;
                audioDoor.Play();
            }else if(Input.GetKeyDown(KeyCode.E) && key.getNumKey() > 0){
                ColliderDoor.SetActive(false);
                TheDoor.GetComponent<SpriteRenderer>().sprite = spriteDoorOpen;
                this.canCoChia = false;
                key.setNumKey();
                audioDoor.clip = clipOpenDoor;
                audioDoor.Play();
            }
            else if(Input.GetKeyDown(KeyCode.E)){
                audioDoor.clip = clipNotKey;
                audioDoor.Play();
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
