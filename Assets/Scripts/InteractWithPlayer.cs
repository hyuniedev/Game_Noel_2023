using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool checkTrigger = false;
    [SerializeField] private GameObject gift;
    private void Start() {
        gift.SetActive(false);
    }
    private void Update() {
        if(checkTrigger){
            gift.SetActive(true);
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
