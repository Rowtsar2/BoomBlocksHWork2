using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Expload(List<Block> blocks, Block clicableBlock)
    {
        foreach (var exploableBlocks in blocks)
        {
            exploableBlocks.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, clicableBlock.transform.position, _explosionRadius);
        }
    }
}
