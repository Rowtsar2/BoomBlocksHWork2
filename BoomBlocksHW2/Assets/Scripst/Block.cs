using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Block : MonoBehaviour
{
    private Rigidbody _rigedbody;
    private Renderer _renderer;

    public float ChanceSeparation { get; private set; } = 100f;
    public Rigidbody GetRigidbody => _rigedbody;

    private void Awake()
    {
        _rigedbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Color color, Vector3 scale, float chance)
    {
        _renderer.material.color = color;
        transform.localScale = scale;
        ChanceSeparation = chance;
    }
}
