using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIControl : MonoBehaviour
{
    public int strength = 5;
    public int usesRemaining = 5;
    public GameObject strengths; 
    public GameObject verseUI;
    // public GameObject black;
    private bool UIOpen = false;  

    void Update() {
        if (strength == 0) {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        if (Keyboard.current.qKey.wasPressedThisFrame && !UIOpen) {
            UIOpen = true;
            verseUI.SetActive(true);
            Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None; 
            Screen.lockCursor = false;
            GameObject.Find("/Canvas/Books/Viewport/Content").transform.position = new Vector3(0, 0, 0);
        } else if (Keyboard.current.qKey.wasPressedThisFrame && UIOpen) {
            UIOpen = false;
            verseUI.SetActive(false);
            Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            Screen.lockCursor = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            strength -= 1;
            strengths.GetComponent<StrengthFadde>().LoseStrength(strength);
            StartCoroutine(WaitToRecheck());
        }
    }

    IEnumerator WaitToRecheck() {
        yield return new WaitForSeconds(2.5f);
    }

    
    /* private int opacity = 0;
    public IEnumerator Fade() {
        Debug.Log("Fading");
        black.SetActive(true);
        
        black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, opacity);
        yield return new WaitForSeconds(1f);

        if (opacity == 255) {
            Debug.Log("Faded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            opacity += 1;
            StartCoroutine(Fade());
        }
    } */
}