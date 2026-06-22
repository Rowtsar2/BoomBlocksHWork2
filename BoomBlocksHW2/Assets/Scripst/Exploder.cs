using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Block> blocks, Block clicableBlock)
    {
        foreach (var exploableBlocks in blocks)
        {
            exploableBlocks.GetRigidbody.AddExplosionForce(_explosionForce, clicableBlock.transform.position, _explosionRadius);
        }
    }

    public void ExplodeFailedSeparation(Block clicableBlcok)
    {
        Vector3 explosionPoint = clicableBlcok.transform.position;

        foreach (var exploableBlock in GetExploadebleObjects(clicableBlcok))
        {
            float distance = Vector3.Distance(exploableBlock.transform.position, explosionPoint);
            float distanceFactor = 1f - (distance / _explosionRadius);

            distanceFactor = Mathf.Clamp01(distanceFactor);

            float finalForce = _explosionForce * distanceFactor * clicableBlcok.PowerExplosion;
            float finalRadius = _explosionRadius * clicableBlcok.PowerExplosion;

            exploableBlock.AddExplosionForce(
                finalForce,
                clicableBlcok.transform.position,
                finalRadius
                );
        }
    }

    private List<Rigidbody> GetExploadebleObjects(Block clicableBlcok)
    {
        List<Collider> collidersHit = Physics.OverlapSphere(clicableBlcok.transform.position, _explosionRadius).ToList();

        List<Rigidbody> rigidbodyBlocks = new();

        foreach (var hit in collidersHit)
        {
            if (hit.attachedRigidbody != null)
            {
                rigidbodyBlocks.Add(hit.attachedRigidbody);
            }
        }

        return rigidbodyBlocks;
    }
}
