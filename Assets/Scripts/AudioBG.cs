using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBG : MonoBehaviour
{
    [SerializeField] private AudioSource audioBG;
    private bool imaStateBGAudio;
    private bool prevStateAudio;

    // Update is called once per frame
    void Update()
    {
        imaStateBGAudio = ButtonController.getOpenAudio();
        if(prevStateAudio!=imaStateBGAudio){
            prevStateAudio = imaStateBGAudio;
            changeStateAudioBG();
        }
    }
    private void changeStateAudioBG(){
        if(imaStateBGAudio){
            audioBG.Play();
        }else{
            audioBG.Stop();
        }
    }
}
