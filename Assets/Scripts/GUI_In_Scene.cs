using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_In_Scene : MonoBehaviour
{
    [SerializeField] private Throw nem;
    [SerializeField] private Text prevForce;
    [SerializeField] private Text curForce;
    private double dPrevForce;
    private double dCurForce;

    // Start is called before the first frame update
    void Start()
    {
        dCurForce = 0;
        dPrevForce = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if(nem.clickDekiru){
            dCurForce = nem.getCurForce();
        }else{
            dPrevForce = dCurForce;
        }
        prevForce.text = "Current Force: " + dPrevForce.ToString("F2") + " N";
        curForce.text = "Old Force: " + dCurForce.ToString("F2") + " N";
    }
}
