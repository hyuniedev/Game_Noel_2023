using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOption;
    [SerializeField] private AudioSource audio;
    public void Play(){
        SceneManager.LoadScene(1);
        audio.Play();
    }
    public void Option(){
        CanvasOption.SetActive(true);
        audio.Play();
    }
    public void ThoatOption(){
        CanvasOption.SetActive(false);
        audio.Play();
    }
    public void Exit(){
        Application.Quit();
        audio.Play();
    }
}
