using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(Vector3 explosionCenterPosition, List<Rigidbody> cubes)
    {
        foreach (Rigidbody explodableTarget in cubes)
            explodableTarget.AddExplosionForce(_explosionForce, explosionCenterPosition, _explosionRadius);
    }

    public void Explode(Vector3 explosionCenterPosition, float explosionCenterSize)
    {
        float explosionForce = CalculateSizeImpact(_explosionForce, explosionCenterSize);
        float explosionRadius = CalculateSizeImpact(_explosionRadius, explosionCenterSize);
        List<Rigidbody> explodableTargets = GetExplodableRigidbodies(explosionCenterPosition, explosionRadius);

        foreach (Rigidbody explodableTarget in explodableTargets)
            explodableTarget.AddExplosionForce(explosionForce, explosionCenterPosition, explosionRadius);
    }

    private float CalculateSizeImpact(float defaultValue, float size)
    {
        float multiplier = 3;
        return defaultValue + defaultValue / size * multiplier;
    }

    private List<Rigidbody> GetExplodableRigidbodies(Vector3 explosionCenter, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(explosionCenter, explosionRadius);

        List<Rigidbody> rigidbodies = new();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                rigidbodies.Add(hit.attachedRigidbody);

        return rigidbodies;
    }
}