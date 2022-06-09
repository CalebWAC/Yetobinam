using UnityEngine;

public class Dispersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var r = new System.Random();
        transform.position = new Vector3(r.Next(-2170, -1170), 60, r.Next(1000));
    }
}
