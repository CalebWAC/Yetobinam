using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfInfluence : MonoBehaviour
{
    public List<GameObject> inRadius = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            inRadius.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            inRadius.Remove(other.gameObject);
        }
    }
}
