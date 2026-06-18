using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;

    private float _chanceSpawn = 100f;
    private float _maxChanceSpawn = 100f;

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
            if (IsSpawn())
            {
                List<Block> blocks = _spawner.SpawnBlocks(GetRandomCount(), block);
                _exploader.Expload(block);
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

    private bool IsSpawn()
    {
        float split = 2f;

        if (_maxChanceSpawn == _chanceSpawn)
        {
            _chanceSpawn /= split;

            return true;
        }
        else
        {
            if (Random.Range(0, _maxChanceSpawn + 1) <= _chanceSpawn)
            {
                _chanceSpawn /= split;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
