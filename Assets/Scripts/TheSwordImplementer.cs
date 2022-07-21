using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TheSwordImplementer : MonoBehaviour
{
    public GameObject sphereOfInfluence;
    public int activeVerse = 1;
    
    public void Implement()
    {
        string book; int chapter; int verse;
        string text = (GameObject.Find($"CV{activeVerse}").GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI).text;
        Parse(text, out book, out chapter, out verse);
        
        switch (book) {
            case "Exo":
                if (chapter == 20) {
                    if (verse == 17) {
                        DestroyEnemy("Envy");
                        Debug.Log("“You shall not covet your neighbor’s house; you shall not covet your neighbor’s wife, or his male servant, or his female servant, or his ox, or his donkey, or anything that is your neighbor’s.”"); // ESV
                    }
                }
                break;
            case "Isa":
                if (chapter == 30) {
                    if (verse == 22) {
                        DestroyEnemy("Idolism");
                        Debug.Log("Then you will defile your carved idols overlaid with silver and your gold-plated metal images. You will scatter them as unclean things. You will say to them, “Be gone!”"); // ESV
                    }
                }
                break;
        }
    }

    // Destroys enemies that are within range and of the same type
    void DestroyEnemy(string type) 
    {
        List<GameObject> inRadius = sphereOfInfluence.GetComponent<SphereOfInfluence>().inRadius;

        foreach (GameObject enemy in inRadius) {
            if (enemy.tag.Contains(type)) {
                Destroy(enemy);
            }
        }
    }

    void Parse(string text, out string book, out int chapter, out int verse) 
    {
        book = text.Substring(0, 3);

        string chapterStr = "";
        string verseStr = "";
        bool onVerse = false;

        foreach (char c in text.Substring(4)) {
            if (c == ':') {
                onVerse = true;
            } else if (!onVerse) {
                chapterStr += c;
            } else {
                verseStr += c;
            }
        } 

        chapter = Int32.Parse(chapterStr);
        verse = Int32.Parse(verseStr);
    }
}