using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float ratateSpeed = 120;
    public float translateSpeed = 5;

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //transform.Rotate(Vector3.up * h * ratateSpeed * Time.deltaTime);
        transform.Translate(new Vector3(h * translateSpeed * Time.deltaTime, 0, v * translateSpeed * Time.deltaTime));
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 50;
        Destroy(bullet, 2);
    }
}