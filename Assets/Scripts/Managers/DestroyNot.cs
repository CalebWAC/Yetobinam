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
            Debug.Log("Hier");
            foreach (Transform child in transform) {
                if (!child.gameObject.name.Contains("Bar")) {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
