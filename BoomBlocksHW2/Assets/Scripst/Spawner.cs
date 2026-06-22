using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefabs;

    public List<Block> SpawnBlocks(int coutBlocks, Block block)
    {
        float reducingSize = 0.5f;
        float separationValue = 2f;
        float additionalForceExplosion = 1f;

        List<Block> blocks = new List<Block>();

        for (int i = 0; i < coutBlocks; i++)
        {
            Block spawnBlock = Instantiate(_blockPrefabs, block.transform.position, Quaternion.identity);

            spawnBlock.Initialize(
                Random.ColorHSV(),
                block.transform.localScale * reducingSize,
                block.ChanceSeparation / separationValue,
                block.PowerExplosion + additionalForceExplosion
                );

            blocks.Add(spawnBlock);
        }

        return blocks;
    }

    public void RemoveBlock(Block block)
    {
        Destroy(block.gameObject);
    }
}
