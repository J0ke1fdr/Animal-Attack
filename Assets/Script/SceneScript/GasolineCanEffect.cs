using UnityEngine;
using System.Collections;

public class GasolineCanEffect : MonoBehaviour
{
    public LayerMask effectMask;
    public ParticleSystem explosionParticle;
    public float explosionForce = 10f;
    public float maxDamage = 100f;
    public float damageRadius = 10f;

    private void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius, effectMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, damageRadius);
            float damage = CalculateDamage(targetRigidbody.position);
            //减血
        }
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
}