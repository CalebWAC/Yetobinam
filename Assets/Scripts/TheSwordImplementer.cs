using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TheSwordImplementer : MonoBehaviour
{
    public GameObject sphereOfInfluence;
    private GameObject selector;

    void Start() {
        selector = GameObject.Find("/Canvas/SelectionBarWeapon/Selector");
    }
    void Update() {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) {
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3 (-0.3332977f, 4.095f, 0);
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
        List<GameObject> inRadius = sphereOfInfluence.GetComponent<SphereOfInfluence>().inRadius;

        foreach (GameObject enemy in inRadius) {
            if (enemy.tag.Contains(type)) {
                Destroy(enemy);
            }
        }
    }
}