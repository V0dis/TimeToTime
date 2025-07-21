using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftMouseClicked;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            LeftMouseClicked?.Invoke();
    }
}