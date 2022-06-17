using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSwordImplementer : MonoBehaviour
{
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

    void Destroy(string type) 
    {
        List<GameObject> inRadius = GameObject.Find("/Player/SphereOfInfluence").GetComponent<SphereOfInfluence>().inRadius;

        foreach (GameObject enemy in inRadius) {
            if (enemy.tag.Contains(type)) {
                Destroy(enemy);
            }
        }
    }
}