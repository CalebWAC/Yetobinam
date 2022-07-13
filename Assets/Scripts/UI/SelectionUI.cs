using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionUI : MonoBehaviour
{
    public GameObject loading;
    public GameObject loadingText;
    public GameObject books;

    public void OnPlay() 
    {
        SceneManager.LoadSceneAsync(2);
        StartCoroutine(Load());
    }

    public void OnEquip()
    {
        books.SetActive(true);
        GameObject.Find("The Implementer").GetComponent<TheImplementer>().buttonText = gameObject.GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
    }

    IEnumerator Load() 
    {
        loadingText.SetActive(true);
        loading.SetActive(true);

        for (int i = 0; i < 10000000; i++) {
            yield return new WaitForSeconds(0.01f);
            loading.transform.Rotate(0, 0, -1f, 0);
        }
    }
}
