using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    private static int numKey = 0;
    [SerializeField] private AudioSource audioKey;
    public int getNumKey(){
        return numKey;
    }
    public void setNumKey(){
        numKey--;
    }
    public static void resetNumKey(){
        numKey = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            numKey++;
            if(ButtonController.getOpenAudio()) audioKey.Play();
            this.gameObject.SetActive(false);
        }
    }
}
