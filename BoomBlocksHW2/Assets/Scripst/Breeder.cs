using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner spawner;

    private void OnEnable()
    {
        _rayCaster.Hit += OnHit;
    }

    private void OnDisable()
    {
        _rayCaster.Hit -= OnHit;
    }

    private void OnHit(RaycastHit raycastHit)
    {
        if (raycastHit.collider.TryGetComponent<Block>(out Block block))
        {
            List<Block> blocks = spawner.SpawnBlocks(5, block);
        }
    }
}
