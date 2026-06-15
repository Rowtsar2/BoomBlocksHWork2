using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
