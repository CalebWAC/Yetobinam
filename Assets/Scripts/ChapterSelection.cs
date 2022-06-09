using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{
    private int verses;
    public GameObject numbers;

    public void GoToVerses() {
        var implementer = GameObject.Find("The Implementer").GetComponent<TheImplementer>();

        if (implementer.onChapters) {
            implementer.chapter = Int32.Parse(gameObject.name);

            verses = GetVersesForChapter(implementer);
            for (int i = 1; i <= verses; i++) {
                // Activate numbers
                string name = $"/Canvas/Chapters-Verses/Viewport/Content/{i}";
                Button ib = GameObject.Find(name).GetComponent<Button>();
                GameObject.Find(name).SetActive(true);

                ColorBlock colors = ib.colors;

                if (implementer.book == "Genesis") {
                    if (implementer.chapter == 1) {
                        if (i == 3) {
                            ib.colors = SetColor(colors, true);
                        } else {
                            ib.colors = SetColor(colors, false);
                        }
                    }
                } else if (implementer.book == "Hebrews") {
                    if (implementer.chapter == 12) {
                        if (i == 29) {
                            ib.colors = SetColor(colors, true);
                        } else {
                            ib.colors = SetColor(colors, false);
                        }
                    }
                } else if (implementer.book == "Psalms") {
                    if (implementer.chapter == 119) {
                        if (i == 133) {
                            ib.colors = SetColor(colors, true);
                        } else {
                            ib.colors = SetColor(colors, false);
                        }
                    }
                } else if (implementer.book == "Ephesians") {
                    if (implementer.chapter == 6) {
                        if (i == 15) {
                            ib.colors = SetColor(colors, true);
                        } else {
                            ib.colors = SetColor(colors, false);
                        }
                    }
                } 
            }

            implementer.onChapters = false;
            GameObject.Find("/Canvas/Chapters-Verses/Viewport/Content").transform.position = new Vector3(0, 0, 0);

            // Deactivate the unused chapters
            for (int i = verses + 1; i <= 32; i++) { // Change the 32 to the number of total chapters
                string name = $"/Canvas/Chapters-Verses/Viewport/Content/{i}";
                GameObject.Find(name).SetActive(false);
            }
        } else {
            implementer.verse = Int32.Parse(gameObject.name);
            implementer.Implement();
            numbers.SetActive(false);
        }
    }

    int GetVersesForChapter(TheImplementer implementer) {
        switch (implementer.book) {
            case "Genesis":
                if (implementer.chapter == 1) {
                    return 31;
                }
                break;
            case "Psalms":
                if (implementer.chapter == 119) {
                    return 176;
                }
                break;
            case "Hebrews":
                if (implementer.chapter == 12) {
                    return 29;
                }
                break;
            case "Ephesians":
                if (implementer.chapter == 6) {
                    return 24;
                }
                break;
        }
        return 0;
    }

    ColorBlock SetColor(ColorBlock colors, bool isActive) {
        if (isActive) {
            colors.normalColor = new Color32(224, 113, 9, 255);
            colors.highlightedColor = new Color32(255, 123, 0, 255);
            return colors;
        } else {
            colors.normalColor = new Color32(200, 200, 200, 255);
            colors.highlightedColor = new Color32(200, 200, 200, 255);
            return colors;
        }
    }
}