using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private int _leftMouseButtonIndex = 0;
    
    public event UnityAction LeftMouseButtonClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonIndex))
        {
            LeftMouseButtonClick?.Invoke();
        }
    }
}
