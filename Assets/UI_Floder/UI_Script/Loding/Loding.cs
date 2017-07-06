using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loding : MonoBehaviour
{
    //private Slider LoadingSlider;
    ////异步对象  
    //private AsyncOperation Progress;

    ////更新Tip的时间  
    //private const float UpdateTime = 0.1F;
    ////上一次更细的时间  
    //private float lastTime = 0.0F;

    //private void Awake()
    //{
    //    LoadingSlider = GameObject.Find("Slider").GetComponent<Slider>();

    //}
    //void Start()
    //{
    //    LoadingSlider.maxValue = 100;

    //    Debug.Log("异步加载场景" + MenuSceneManager.choosedScene);
    //    Progress = SceneManager.LoadSceneAsync(MenuSceneManager.choosedScene);
    //}

    public Slider processBar;
    private Text ProcessText;
    private Text tips;
    private AsyncOperation async;

    private int nowProcess;

    private void Start()
    {
        processBar = GameObject.Find("Slider").GetComponent<Slider>();
        ProcessText = GameObject.Find("ProcessText").GetComponent<Text>();
        tips = GameObject.Find("tips").GetComponent<Text>();
        StartCoroutine(loadScene());
        processBar.maxValue = 100;

        string[] Tips = { "通关更多关卡可以解锁更多英雄哦",
            "可以通过打怪来获取更多武器",
            "场景中有些地方可以降落补给哦",
        "补给箱不及时检会消失的哦","看看你能在无尽模式中坚持到多少关"};

        int tipIndex = Random.Range(0, Tips.Length);
        // Debug.Log("tip" + tipIndex);
        tips.text = "tips:" + Tips[tipIndex];
    }

    /// <summary>  
        /// 加载完场景后就会跳转  
        /// </summary>  
        /// <returns></returns>  
    private IEnumerator loadScene()
    {
        async = SceneManager.LoadSceneAsync(MenuSceneManager.choosedScene);
        async.allowSceneActivation = false;
        yield return async;
    }

    private void Update()
    {
        if (async == null)
        {
            return;
        }

        int toProcess;
        // async.progress 你正在读取的场景的进度值  0---0.9    
        // 如果当前的进度小于0.9，说明它还没有加载完成，就说明进度条还需要移动    
        // 如果，场景的数据加载完毕，async.progress 的值就会等于0.9  
        if (async.progress < 0.9f)
        {
            toProcess = (int)async.progress * 100;
        }
        else
        {
            toProcess = 100;
        }
        // 如果滑动条的当前进度，小于，当前加载场景的方法返回的进度   
        if (nowProcess < toProcess)
        {
            nowProcess++;
        }

        processBar.value = nowProcess;
        ProcessText.text = processBar.value.ToString() + "%";
        // 设置为true的时候，如果场景数据加载完毕，就可以自动跳转场景   
        if (nowProcess == 100)
        {
            async.allowSceneActivation = true;
        }
    }
}