using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private int _leftMouseButtonIndex = 0;
    
    public event UnityAction MouseButtonClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonIndex))
        {
            MouseButtonClick?.Invoke();
        }
    }
}
