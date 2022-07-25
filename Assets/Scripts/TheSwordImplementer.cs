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
        string text = (GameObject.Find($"CV{activeVerse}").GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI).text;
        
        if (text == "Exo 20:17") {
            DestroyEnemy("Envy");
            Debug.Log("“You shall not covet your neighbor’s house; you shall not covet your neighbor’s wife, or his male servant, or his female servant, or his ox, or his donkey, or anything that is your neighbor’s.”"); // ESV
        } else if (text == "Isa 30:22") {
            DestroyEnemy("Idolism");
            Debug.Log("Then you will defile your carved idols overlaid with silver and your gold-plated metal images. You will scatter them as unclean things. You will say to them, “Be gone!”"); // ESV
        } else if (text == "Jer 13:15") {
            DestroyEnemy("Pride");
            Debug.Log("Hear and give ear; be not proud, for the LORD has spoken."); // ESV
        } else if (text == "Job 31:1") {
            DestroyEnemy("Lust");
            Debug.Log("“I made a covenant with my eyes not to look lustfully at a young woman."); // NIV
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
}