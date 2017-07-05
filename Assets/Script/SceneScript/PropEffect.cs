using UnityEngine;
using System.Collections;

public class PropEffect : MonoBehaviour
{
    public LayerMask effectMask;
    public LayerMask propMask;
    public ParticleSystem explosionParticle;
    public float maxDamage = 100f;
    public float damageRadius = 50f;
    public float deadTime = 0.5f;

    private void Start()
    {
        MusicPlay();

        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius, effectMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag != "Enemy")
                continue;
            int damage = (int)CalculateDamage(colliders[i].transform.position);

            //减血
            colliders[i].gameObject.SendMessage("ApplyDamage", damage);
        }

        Collider[] Propcolliders = Physics.OverlapSphere(transform.position, damageRadius, propMask);
        Debug.Log(Propcolliders.Length);
        for (int i = 0; i < Propcolliders.Length; i++)
        {
            if (Propcolliders[i].gameObject.tag != "Prop")
                continue;
            int damage = (int)CalculateDamage(Propcolliders[i].transform.position);

            //减血
            Propcolliders[i].gameObject.SendMessage("ApplyDamage", damage);
        }
        explosionParticle.Play();

        Destroy(gameObject, deadTime);
    }

    private float CalculateDamage(Vector3 targetPostion)
    {
        Vector3 explosionToTarget = targetPostion - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (damageRadius - explosionDistance) / damageRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0, damage);
        return damage;
    }

    public void MusicPlay()
    {
        bool musicPlay = PlayerPrefs.GetInt("CharacterMusicSetting", 1) == 1 ? true : false;
        if (musicPlay)
            GetComponent<AudioSource>().Play();
    }
}