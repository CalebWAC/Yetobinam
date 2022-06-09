using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VerseUI : MonoBehaviour
{
    public GameObject content;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.scroll.ReadValue().y < 0) {
            content.transform.position = new Vector3(content.transform.position.x, content.transform.position.y - 70, content.transform.position.z);
        }

        if (Mouse.current.scroll.ReadValue().y > 0) {
            content.transform.position = new Vector3(content.transform.position.x, content.transform.position.y + 70, content.transform.position.z);
        }
    }
}