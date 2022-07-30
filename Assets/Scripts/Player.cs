using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int strength = 5;
    public GameObject strengths; 
    public bool inWater = false; 

    private PlayerInput PI;
    private StarterAssets.ThirdPersonController tpc;
    private GameObject water;
    private bool justInWater = false;

    void Start() 
    {
        PI = GetComponent<PlayerInput>();
        tpc = GetComponent<StarterAssets.ThirdPersonController>();
    }

    void Update()
    {
        if (strength == 0) {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        if (inWater) {
            transform.position = new Vector3 (transform.position.x, water.transform.position.y - 0.9f, transform.position.z);
        }

        if (tpc.Grounded && inWater && !justInWater) {
            Debug.Log("Switching to Player");
            PI.SwitchCurrentActionMap("Player");
            tpc.Gravity = -15;
            inWater = false;
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
        } else if (other.gameObject.layer == 4) {
            Debug.Log("Switching to Water");
            PI.SwitchCurrentActionMap("Water");
            tpc.Gravity = 0;
            inWater = true;
            water = other.gameObject;
            StartCoroutine(WaitForWater());
        }
    }

    IEnumerator WaitToRecheck() {
        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator WaitForWater() {
        justInWater = true;
        yield return new WaitForSeconds(1f);
        justInWater = false;
    }

    void OnAttack()
    {
        GameObject.Find("The Implementer").GetComponent<TheSwordImplementer>().Implement();
    }
}
