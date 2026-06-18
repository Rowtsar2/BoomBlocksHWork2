using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Expload(Block block)
    {
        foreach (var exploableBlocks in GetExplodableObjects(block))
        {
            exploableBlocks.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, block.transform.position, _explosionRadius);
            Debug.Log("Взрыв в нутри форыч");
        }

        Debug.Log("Взрыв в методе после");
    }

    private List<Rigidbody> GetExplodableObjects(Block pointExpload)
    {
        Collider[] hits = Physics.OverlapSphere(pointExpload.transform.position, _explosionRadius);

        List<Rigidbody> rigitbodyBloks = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                rigitbodyBloks.Add(hit.attachedRigidbody);
            }
        }

        return rigitbodyBloks;
    }
}
