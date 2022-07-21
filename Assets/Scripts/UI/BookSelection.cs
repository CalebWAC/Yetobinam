using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSelection : MonoBehaviour
{
    public int chapters;
    public GameObject books;
    public GameObject number;
    public GameObject context;

    public void GoToChapters() {
        number.SetActive(true);
        for (int i = 1; i <= chapters; i++) {
            // Activate numbers
            string name = $"/Canvas/Chapters-Verses/Viewport/Content/{i}";
            Button ib = GameObject.Find(name).GetComponent<Button>();
            GameObject.Find(name).SetActive(true);
            context.SetActive(true); // context.transform.position = new Vector3(0, 0, 0);

            ColorBlock colors = ib.colors;

            // Color the active chapters by book
            switch (gameObject.name) {
                case "Genesis":
                    if (i == 1) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
                case "Exodus":
                    if (i == 20) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
                case "Psalms":
                    if (i == 119) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
                case "Isaiah":
                    if (i == 30) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
                case "Hebrews":
                    if (i == 12 || i == 4) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
                case "Ephesians":
                    if (i == 6) {
                        ib.colors = SetColor(colors, true);
                    } else {
                        ib.colors = SetColor(colors, false);
                    }
                    break;
            }
        }

        // Deactivate the unused chapters
        for (int i = chapters + 1; i <= 68; i++) { // Change the 68 to the number of total chapters
            string name = $"/Canvas/Chapters-Verses/Viewport/Content/{i}";
            GameObject.Find(name).SetActive(false);
        }

        GameObject.Find("The Implementer").GetComponent<TheImplementer>().book = gameObject.name;
        GameObject.Find("The Implementer").GetComponent<TheImplementer>().onChapters = true;
        books.SetActive(false);
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