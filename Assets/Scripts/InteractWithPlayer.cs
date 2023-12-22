using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactWithPlayer : MonoBehaviour
{
    private bool checkTrigger = false;
    [SerializeField] private GameObject gift;
    [SerializeField] private GameObject player;
    private void Start() {
        gift.SetActive(false);
    }
    private void Update() {
        if(checkTrigger){
            gift.SetActive(true);
            player.GetComponent<WinnerCheck>().incNumGiftBed();
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                checkTrigger = true;
            }
        }
    }
}
