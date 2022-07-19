using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheImplementer : MonoBehaviour
{
    public string book;
    public int chapter;
    public int verse;

    [Space(15)]
    [Header("Implementations")]
    public GameObject fire;
    public GameObject pointer; 
    public GameObject light;
    public GameObject sword;

    [HideInInspector]
    public bool onChapters = false;
    public TMPro.TextMeshProUGUI buttonText;
    private int usesRemaining = 5;

    public void Implement() {
        if (SceneManager.GetActiveScene().buildIndex != 1) {
            if (usesRemaining != 0) {
                switch (book) {
                    case "Genesis":
                        if (chapter == 1) {
                            if (verse == 3) {
                                light.SetActive(true);
                                StartCoroutine(Wait(60));
                                Debug.Log("And God said, “Let there be light,” and there was light."); // ESV
                                // That was God, I was quoting God there.  
                            }
                        }
                        break;
                    case "Psalms":
                        if(chapter == 119) {
                            if (verse == 133) {
                                pointer.SetActive(true);
                                Debug.Log("Direct my footsteps according to your word, let no sin rule over me."); // NIV
                            }
                        }
                        break;
                    case "Hebrews":
                        if (chapter == 12) {
                            if (verse == 29) {
                                fire.SetActive(true);
                                Debug.Log("for our God is a consuming fire."); // ESV
                            }
                        } /* else if (chapter == 4) {
                            if (verse == 12) {
                                sword.SetActive(true);
                                Debug.Log("For the word of God is living and active, sharper than any two-edged sword, piercing to the division of soul and of spirit, of joints and of marrow, and discerning the thoughts and intentions of the heart."); // ESV
                            }
                        } */
                        break;
                    case "Ephesians":
                        if (chapter == 6) {
                            if (verse == 15) {
                                var tpc = GameObject.Find("Player").GetComponent<StarterAssets.ThirdPersonController>();
                                tpc.MoveSpeed = 10;
                                tpc.SprintSpeed = 15;
                                Debug.Log("and, as shoes for your feet, having put on the readiness given by the gospel of peace"); // ESV
                            }
                        }
                        break;
                }

                Resolve();
            }
        } else {
            Set();
        }
    }

    public void Set() 
    {
        buttonText.text = $"{book.Substring(0, 3)} {chapter}:{verse}";
    }

    void Resolve() {
        // Lose a usage
        GameObject.Find($"/Canvas/Uses/U{usesRemaining - (usesRemaining - 1)}").SetActive(false);
        usesRemaining--;

        // Reset values
        book = "";
        chapter = 0;
        verse = 0;

        // Lock cursor
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

    IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        light.SetActive(false);
    }
}