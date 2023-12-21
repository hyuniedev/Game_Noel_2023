using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOption;
    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void Option(){
        CanvasOption.SetActive(true);
    }
    public void ThoatOption(){
        CanvasOption.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
}
