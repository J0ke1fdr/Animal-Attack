using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class repeatButtonClick : MonoBehaviour {

	public void onRepeatClick()
    {
        SceneManager.LoadScene(1);
    }
}
