using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class homeButtonClick : MonoBehaviour {

	public void onHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
