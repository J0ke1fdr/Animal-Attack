using UnityEngine;
using System.Collections;

public class DropPropManager : MonoBehaviour
{
    //间隔时间
    public float timeSpan = 60;

    public int propDeadTime = 30;

    //武器和血包的生成概率比例：武器/血包
    public int probabilityScale = 5;

    public GameObject bloodBag;
    public GameObject randBox;
    private float xWidth;
    private float zWidth;
    private float lastInstantiateTime = 0;

    private enum InstantiateType
    {
        BloodBag,
        Weapon
    }

    private void Start()
    {
        xWidth = GetComponent<Collider>().bounds.size.x / 2;
        zWidth = GetComponent<Collider>().bounds.size.z / 2;
    }

    private void Update()
    {
        if (Time.time - lastInstantiateTime >= timeSpan)
        {
            lastInstantiateTime = Time.time;
            Vector3 instantiatePos = InstantiatePosition();
            if (RandInstantiateType() == InstantiateType.BloodBag)
            {
                GameObject bloodbag = Instantiate(bloodBag, transform) as GameObject;
                bloodbag.transform.position = instantiatePos;
                bloodbag.GetComponent<BloodBag>().DestroyProp(propDeadTime);
            }
            else
            {
                GameObject randbox = Instantiate(randBox, transform) as GameObject;
                randbox.transform.position = instantiatePos;
                randbox.GetComponent<RandBox>().DestroyProp(propDeadTime);
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