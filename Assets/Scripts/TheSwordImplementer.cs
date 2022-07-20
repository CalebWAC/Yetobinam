using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TheSwordImplementer : MonoBehaviour
{
    public GameObject sphereOfInfluence;
    
    public void Implement(string book, int chapter, int verse)
    {
        switch (book) {
            case "Exodus":
                if (chapter == 20) {
                    if (verse == 17) {
                        Destroy("Envy");
                        Debug.Log("“You shall not covet your neighbor’s house; you shall not covet your neighbor’s wife, or his male servant, or his female servant, or his ox, or his donkey, or anything that is your neighbor’s.”");
                    }
                }
                break;
        }
    }

    // Destroys enemies that are within range and of the same type
    void Destroy(string type) 
    {
        List<GameObject> inRadius = sphereOfInfluence.GetComponent<SphereOfInfluence>().inRadius;

        foreach (GameObject enemy in inRadius) {
            if (enemy.tag.Contains(type)) {
                Destroy(enemy);
            }
        }
    }
}