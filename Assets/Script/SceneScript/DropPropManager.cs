using UnityEngine;
using System.Collections;

public class DropPropManager : MonoBehaviour
{
    //间隔时间
    public float timeSpan = 60;

    //最大生成数
    public int maxcount = 5;

    //武器和血包的生成概率比例：武器/血包
    public int probabilityScale = 5;

    public GameObject bloodBag;
    public GameObject randBox;
    private float xWidth;
    private float zWidth;
    private int realCount;
    private float lastInstantiateTime = 0;
    private int currentCount = 0;

    private enum InstantiateType
    {
        BloodBag,
        Weapon
    }

    private void Start()
    {
        realCount = Random.Range(0, maxcount + 1);
        xWidth = GetComponent<Collider>().bounds.size.x / 2;
        zWidth = GetComponent<Collider>().bounds.size.z / 2;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time - lastInstantiateTime >= timeSpan && currentCount < realCount)
        {
            currentCount++;
            lastInstantiateTime = Time.time;
            Vector3 instantiatePos = InstantiatePosition();
            if (RandInstantiateType() == InstantiateType.BloodBag)
            {
                GameObject bloodbag = Instantiate(bloodBag, transform) as GameObject;
                bloodbag.transform.position = instantiatePos;
            }
            else
            {
                GameObject randbox = Instantiate(randBox, transform) as GameObject;
                randbox.transform.position = instantiatePos;
            }
        }
    }

    private Vector3 InstantiatePosition()
    {
        float xrange = Random.Range(-xWidth, xWidth);
        float zrange = Random.Range(-zWidth, zWidth);
        return new Vector3(transform.position.x + xrange, transform.position.y, transform.position.z + zrange);
    }

    private InstantiateType RandInstantiateType()
    {
        int rand = Random.Range(0, probabilityScale + 1);
        if (rand == probabilityScale)
            return InstantiateType.BloodBag;
        else
            return InstantiateType.Weapon;
    }
}