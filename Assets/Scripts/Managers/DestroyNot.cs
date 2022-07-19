using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyNot : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 2) {
            foreach (Transform child in transform) {
                if (!child.gameObject.name.Contains("SelectionBar")) {
                    child.gameObject.SetActive(false);
                } else if (child.gameObject.name.Contains("Weapon")) {
                    GameObject.Find($"/Canvas/{child.gameObject.name}/Selector").SetActive(true);
                }
            }
        }
    }
}
