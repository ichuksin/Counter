using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _coroutine = null;
    private float _delay = 0.5f;
    private int _counter = 0;

    public event UnityAction<int> CounterChanged;

    private void OnEnable()
    {
        _inputReader.LeftMouseButtonClick += OnMouseButtonClick;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseButtonClick -= OnMouseButtonClick;
    }

    private void Start()
    {
        CounterChanged?.Invoke(_counter);
    }

    private void OnMouseButtonClick()
    {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Timer(_delay));
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
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
