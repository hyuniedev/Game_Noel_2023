using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : MonoBehaviour
{
    [SerializeField] private HumanMoveAuto ma;
    [SerializeField] private AudioSource audioGhost;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            audioGhost.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GetComponent<SpriteRenderer>().color = new Color(255.0f/255.0f,171.0f/255.0f,171.0f/255.0f,75.0f/255.0f);
            ma.phatHien = true;    
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GetComponent<SpriteRenderer>().color = new Color(171.0f/255.0f,255.0f/255.0f,171.0f/255.0f,75.0f/255.0f);
            ma.phatHien = false;
            audioGhost.Stop();
        }
    }
}
