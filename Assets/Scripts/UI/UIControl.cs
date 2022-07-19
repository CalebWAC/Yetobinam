using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public int usesRemaining = 5;
    public GameObject verseUI;
    private bool UIOpen = false;  

    void OnMenu() 
    {
        if (!UIOpen) {
            UIOpen = true;
            verseUI.SetActive(true);
            Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None; 
            Screen.lockCursor = false;
            GameObject.Find("/Canvas/Books/Viewport/Content").transform.position = new Vector3(0, 0, 0);
        } else {
            UIOpen = false;
            verseUI.SetActive(false);
            Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            Screen.lockCursor = true;
        }
    }
}