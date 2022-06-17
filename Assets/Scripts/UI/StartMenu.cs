using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    [Header("Start Options")]
    public GameObject play;
    public GameObject tutorial;
    public GameObject settings;

    [Space(20)]
    [Header("Play Options")]
    public GameObject solo;
    public GameObject localMultiplayer;
    public GameObject onlineMultiplayer;

    public void OnClick() 
    {
        if (gameObject.name == "Play") {
            solo.SetActive(true);
            localMultiplayer.SetActive(true);
            onlineMultiplayer.SetActive(true);

            tutorial.SetActive(false);
            settings.SetActive(false);
            play.SetActive(false);
        }

        if (gameObject.name == "Solo") {
            SceneManager.LoadScene("Playground");
        }
    }
}
