using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _layerMask;

    public event Action<RaycastHit> Hit;

    private void OnEnable()
    {
        _inputReader.Clicked += OnInputReaderClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnInputReaderClicked;
    }

    private void OnInputReaderClicked(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            Hit?.Invoke(hit);
        }
    }
}
