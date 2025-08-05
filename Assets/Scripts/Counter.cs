using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private int _leftMouseButtonIndex = 0;
    private Coroutine _coroutine;
    private float _delay = 0.5f;
    private int _counter = 0;
    private bool isWork = false;

    public event UnityAction<int> CounterChanged;

    private void Start()
    {
        CounterChanged?.Invoke(_counter);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonIndex))
        {
            if (isWork)
            {
                isWork = false;
                StopCoroutine(_coroutine);
            }
            else
            {
                isWork = true;
                _coroutine = StartCoroutine(Timer(_delay));
            }
        }
    }

    private IEnumerator Timer(float delay)
    {
        var wait = new WaitForSeconds (delay);
        
        while (enabled)
        {
            _counter++;
            CounterChanged?.Invoke(_counter);
            yield return wait;
        }
    }
}
