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
    private bool click1Lanthoi = true;
    private void Start() {
        imgGhost.SetActive(false);
    }
    private void Update() {
        if(checkTrigger && click1Lanthoi){
            ButtonControl.OnOffAudio();
            audioGhost.Play();
            CanvasPlay.SetActive(false);
            imgGhost.transform.position = Camera.main.transform.position+
            new Vector3(0,0,4);
            SantaMove.move = false;
            imgGhost.SetActive(true);
            Invoke(nameof(hideImgGhost),2.2f);
            click1Lanthoi = false;
            checkTrigger = false;
        }
    }
    private void hideImgGhost(){
        SantaMove.move = true;
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
