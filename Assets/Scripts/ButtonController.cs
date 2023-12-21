using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Text txtKey;
    [SerializeField] private KeyController key;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject btn_menu;
    private void Start() {
        ui.SetActive(false);
        btn_menu.SetActive(true);
    }
    private void Update() {
        txtKey.text = "X" + key.getNumKey();
        if(Input.GetKeyDown(KeyCode.E) && key.getNumKey() <= 0){
            CanhCao();
        }
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
    public void CanhCao(){
        txtKey.color = Color.red;
        Invoke(nameof(resetColor),2.0f);
    }
    private void resetColor(){
        txtKey.color = Color.yellow;
    }
}
