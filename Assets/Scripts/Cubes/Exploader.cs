using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> cubes, Vector3 explosionCenter)
    {
        foreach (Rigidbody explodableTargets in cubes)
            explodableTargets.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
    }
}