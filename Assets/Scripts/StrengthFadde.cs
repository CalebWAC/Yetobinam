using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthFadde : MonoBehaviour
{
    public GameObject FS1;
    public GameObject FS2;
    public GameObject FS3;
    public GameObject FS4;
    public GameObject FS5;

    public void LoseStrength(int strength) {
        switch (strength) {
            case 4:
                FS1.SetActive(true);
                break;
            case 3:
                FS2.SetActive(true);
                break;
            case 2:
                FS3.SetActive(true);
                break;
            case 1:
                FS4.SetActive(true);
                break;
            case 0:
                FS5.SetActive(true);
                break;
        }
    }
}
