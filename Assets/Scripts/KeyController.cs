using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    private static int numKey;
    [SerializeField] private AudioSource audio;
    private void Start() {
        numKey = 0;
    }
    public int getNumKey(){
        return numKey;
    }
    public void setNumKey(){
        numKey--;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            numKey++;
            audio.Play();
            this.gameObject.SetActive(false);
        }
    }
}
