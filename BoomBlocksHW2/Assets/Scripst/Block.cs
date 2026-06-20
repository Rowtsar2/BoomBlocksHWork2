using UnityEngine;

public class Block : MonoBehaviour
{
    public float ChanceSeparation { get; private set; } = 100f;

    public void Initialize(Color color, Vector3 scale, float chance)
    {
        GetComponent<Renderer>().material.color = color;
        transform.localScale = scale;
        ChanceSeparation = chance;
    }
}
