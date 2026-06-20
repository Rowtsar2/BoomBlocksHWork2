using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;

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
            if (IsSpawn(block))
            {
                List<Block> blocks = _spawner.SpawnBlocks(GetRandomCount(), block);
                _exploader.Expload(blocks, block);
                _spawner.RemoveBlock(block);
            }
            else
            {
                _spawner.RemoveBlock(block);
            }
        }
    }

    private int GetRandomCount()
    {
        int minValue = 2;
        int maxValue = 6;

        return Random.Range(minValue, maxValue);
    }

    private bool IsSpawn(Block block)
    {
        float maxChanceSpawn = 100 + 1f;

        if (maxChanceSpawn == block.ChanceSeparation)
        {
            return true;
        }
        else
        {
            if (Random.Range(0, maxChanceSpawn) <= block.ChanceSeparation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
