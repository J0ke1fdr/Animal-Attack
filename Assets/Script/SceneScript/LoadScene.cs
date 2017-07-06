using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    private float curProgress = 0;
    public Slider slider;
    public Text text;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        asyncOperation = SceneManager.LoadSceneAsync(4);
        asyncOperation.allowSceneActivation = true;

        yield return asyncOperation;
    }

    private void Update()
    {
        curProgress = asyncOperation.progress;
        Debug.Log("CurrentProgress: " + curProgress + ":::" + asyncOperation.progress);
        slider.value = curProgress;
        text.text = curProgress.ToString();
    }
}