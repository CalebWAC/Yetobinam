using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public int usesRemaining = 5;
    public GameObject verseUI;
    private bool UIOpen = false; 

    private GameObject selector;

    void Start() {
        selector = GameObject.Find("/Canvas/SelectionBarWeapon/Selector");
    }

    // Moves selector for active verse
    void Update() {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, 4.095f, 0);
        } else if (Keyboard.current.digit2Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, 1.750061f - 0.030061f, 0);
        } else if (Keyboard.current.digit3Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, -0.624939f - 0.030061f, 0);
        } else if (Keyboard.current.digit4Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, -2.999939f - 0.030061f, 0);
        } else if (Keyboard.current.digit5Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, -5.374954f - 0.030061f, 0);
        }
    }

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

    // Moves selector for gamepad
    void OnSwitch(InputValue value)
    {
        float lr = value.Get<float>();

        if (lr == 1) {
            Debug.Log("Ich bin hier");
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, selector.GetComponent<RectTransform>().anchoredPosition.y + 2.375f, 0);
        } else if (lr == -1) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, selector.GetComponent<RectTransform>().anchoredPosition.y + -2.375f, 0);
        }

        if (selector.GetComponent<RectTransform>().anchoredPosition.y > 4.095f) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, -5.374954f - 0.030061f, 0);
        } else if (selector.GetComponent<RectTransform>().anchoredPosition.y < -6f) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.3332977f, 4.095f, 0);
        }
    }
}