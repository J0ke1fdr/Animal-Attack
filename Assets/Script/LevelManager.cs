using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    private int level = 1;
    private int maxCountInMap = 20;              //地图上最多同时存在的怪物数目
    private int enemyRemainCountLevel = 10;           //当前关卡剩余未生成怪物数
    public int enemyCountAll;                   //当前关卡的怪物总数
    public int enemyCountLive;                  //当前地图剩余怪物数目
    public GameObject crow;
    public GameObject crab;
    public GameObject pig;

    public List<GameObject> AnimalList = new List<GameObject>();
    public Transform[] CreateAnimalPoint = new Transform[7];

    public Light globalLight;

    private levelShow levelshow;

    private void Start()
    {
        levelshow = GameObject.Find("levelShow").GetComponent<levelShow>();
        levelshow.ShowCurrentLevel(level);
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyUp(KeyCode.J))
        {
            LevelUp();
        }*/

        if (enemyRemainCountLevel > 0 && AnimalList.Count < maxCountInMap)
        {
            CreateAnimalAtRandomPoint();
            //Debug.Log(enemyRemainCountLevel + "+" + AnimalList.Count);
        }
        if (enemyRemainCountLevel <= 0 && AnimalList.Count <= 0)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// 下一关
    /// </summary>
    public void LevelUp()
    {
        level++;
        enemyRemainCountLevel = 5 + level * 5;
        levelshow.ShowCurrentLevel(level);
        AdjustLighting();
    }

    /// <summary>
    /// 根据当前level调节光照强度
    /// </summary>
    public void AdjustLighting()
    {
        int kind = level % 6;
        float intensity = 0f;
        switch (kind)
        {
            case 2: intensity = 1f; break;
            case 1:
            case 3: intensity = 0.5f; break;
            case 4:
            case 6: intensity = 0.2f; break;
            case 5: intensity = 0f; break;
        }

        StartCoroutine(smoothAdjust(intensity));
    }

    /// <summary>
    /// 平滑调整光照强度
    /// </summary>
    /// <param name="intensity">目标强度</param>
    /// <returns></returns>
    private IEnumerator smoothAdjust(float intensity)
    {
        float origin = globalLight.intensity;
        for (int i = 0; i < 40; i++)
        {
            globalLight.intensity += (intensity - origin) / 40;
            if (globalLight.intensity >= intensity)
            {
                globalLight.intensity = intensity;
                break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void CreateAnimalATPoint(Transform Point)
    {
        AnimalList.Add((GameObject)Instantiate(crow, Point.position, Point.rotation));
        enemyRemainCountLevel--;
    }

    private void CreateAnimalAtRandomPoint()
    {
        int No = Random.Range(0, 7);
        AnimalList.Add((GameObject)Instantiate(crow, CreateAnimalPoint[No].position, CreateAnimalPoint[No].rotation));
        enemyRemainCountLevel--;
        if ((enemyRemainCountLevel % 7) == 0)
        {
            AnimalList.Add((GameObject)Instantiate(crab, CreateAnimalPoint[No].position, CreateAnimalPoint[No].rotation));
            enemyRemainCountLevel--;
        }

        if ((enemyRemainCountLevel % 10) == 0)
        {
            AnimalList.Add((GameObject)Instantiate(pig, CreateAnimalPoint[No].position, CreateAnimalPoint[No].rotation));
            enemyRemainCountLevel--;
        }
    }

    public void AddEnemyCount()
    {
        enemyCountLive++;
    }

    public void ReduceEnemyCount()
    {
        enemyCountLive--;
        //List<int> a = new List<int>();
        //a.Remove(ga);
    }

    public int getLevel()
    {
        return level;
    }

    public void AnimalDie(GameObject DeadAnimal)
    {
        AnimalList.Remove(DeadAnimal);
        Debug.Log(enemyRemainCountLevel + "+" + AnimalList.Count);
    }
}