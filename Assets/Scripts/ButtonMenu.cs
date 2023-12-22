using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOption;
    [SerializeField] private AudioSource audioMenu;
    public void Play(){
        KeyController.resetNumKey();
        if(ButtonController.getOpenAudio()) audioMenu.Play();
        SceneManager.LoadScene(1);
    }
    public void Option(){
        CanvasOption.SetActive(true);
        if(ButtonController.getOpenAudio()) audioMenu.Play();
    }
    public void ThoatOption(){
        CanvasOption.SetActive(false);
        if(ButtonController.getOpenAudio()) audioMenu.Play();
    }
    public void Exit(){
        Application.Quit();
        if(ButtonController.getOpenAudio()) audioMenu.Play();
    }
}
