using UnityEngine;

public class Breeder : MonoBehaviour
{
    [SerializeField] private Block _blockPrefabs;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Нажал мышку");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.TryGetComponent<Block>(out _blockPrefabs))
                {
                    GameObject block = hit.collider.gameObject;
                    
                    SpawnBlocks(block);
                    HideBlock(hit);
                }
                else
                {
                    return;
                }
            }

        }
    }

    private void HideBlock(RaycastHit hit)
    {
        Destroy(hit.collider.gameObject);
    }

    private void SpawnBlocks(GameObject block)
    {
        for (int i = 0; i < 3; i++)
        {
            var spawnBlock = Instantiate(block, block.transform.position, Quaternion.identity);

            //spawnBlock.GetComponent<Block>();
            spawnBlock.transform.localScale *= 0.5f;

        }
    }
}
