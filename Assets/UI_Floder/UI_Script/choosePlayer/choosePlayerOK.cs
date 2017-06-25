using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class choosePlayerOK : MonoBehaviour {

    private Transform choosePlayerIndex;

    private void Start()
    {
        choosePlayerIndex = GameObject.Find("choosePlayerIndex").GetComponent <Transform> ();
    }
    public void onChoosePlayerOkClick()
    {
        DontDestroyOnLoad(choosePlayerIndex.gameObject);
        SceneManager.LoadScene(2);
    }
}
