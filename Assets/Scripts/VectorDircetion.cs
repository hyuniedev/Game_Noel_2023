using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_In_Scene : MonoBehaviour
{
    [SerializeField] private Throw _throw;
    private void Update() {
        transform.up = -1 * _throw.getVectorMouse();
    }
}
