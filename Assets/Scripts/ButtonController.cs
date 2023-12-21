using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject btn_menu;
    private void Start() {
        ui.SetActive(false);
        btn_menu.SetActive(true);
    }
    public void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueScene(){
        btn_menu.SetActive(true);
        ui.SetActive(false);
    }
    public void MenuOpen(){
        btn_menu.SetActive(false);
        ui.SetActive(true);
    }
    public void ReturnGameMenu(){
        SceneManager.LoadScene(0);
    }
}
