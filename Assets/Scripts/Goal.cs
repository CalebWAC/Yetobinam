using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-15, 75), 45, UnityEngine.Random.Range(-115, 45));
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate() {
        transform.Rotate(0, 1, 0);
        yield return new WaitForSeconds(0.1f);
    }
}
