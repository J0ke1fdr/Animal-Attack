using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOverButtonClick : MonoBehaviour {

    public void onGameOverButtonClick()
    {
        switch(gameObject.name)
        {
            case "repeatButton":Repeat(); break;
            case "homeButton": Home();break;
            case "quitButton": Quit();break;
        }
    }

    public void Repeat()
    {
        Debug.Log("Repeat");
        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        Debug.Log("home");
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
