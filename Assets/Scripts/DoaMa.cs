using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoaMa : MonoBehaviour
{
    private bool checkTrigger = false;
    [SerializeField] private GameObject imgGhost;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject CanvasPlay;
    [SerializeField] private ButtonController ButtonControl;
    [SerializeField] private AudioSource audioGhost;
    private void Start() {
        imgGhost.SetActive(false);
    }
    private void Update() {
        if(checkTrigger){
            ButtonControl.OnOffAudio();
            audioGhost.Play();
            Debug.Log("Phat am thanh cua ma roif");
            CanvasPlay.SetActive(false);
            imgGhost.transform.position = player.transform.position +
            new Vector3(0,0.1f,0);
            imgGhost.SetActive(true);
            Invoke(nameof(hideImgGhost),2f);
            checkTrigger = false;
        }
    }
    private void hideImgGhost(){
        ButtonControl.OnOffAudio();
        CanvasPlay.SetActive(true);
        imgGhost.SetActive(false);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                checkTrigger = true;
            }
        }
    }
}
