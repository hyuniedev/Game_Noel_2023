using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOption;
    [SerializeField] private AudioSource audioMenu;
    public void Play(){
        SceneManager.LoadScene(1);
        audioMenu.Play();
    }
    public void Option(){
        CanvasOption.SetActive(true);
        audioMenu.Play();
    }
    public void ThoatOption(){
        CanvasOption.SetActive(false);
        audioMenu.Play();
    }
    public void Exit(){
        Application.Quit();
        audioMenu.Play();
    }
}
