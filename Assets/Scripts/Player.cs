using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int strength = 5;
    public GameObject strengths; 

    void Update()
    {
        if (strength == 0) {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Contains("Enemy")) {
            strength -= 1;
            strengths.GetComponent<StrengthFadde>().LoseStrength(strength);
            StartCoroutine(WaitToRecheck());
        } else if (other.gameObject.tag == "Goal") {
            GameObject.Find("/Player/Confetti").GetComponent<ParticleSystem>().Play();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator WaitToRecheck() {
        yield return new WaitForSeconds(2.5f);
    }
}
