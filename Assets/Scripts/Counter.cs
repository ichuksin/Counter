using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _coroutine = null;
    private float _delay = 0.5f;
    private int _value = 0;

    public event UnityAction<int> CounterChanged;

    private void OnEnable()
    {
        _inputReader.MouseButtonClick += OnMouseButtonClick;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClick -= OnMouseButtonClick;
    }

    private void OnMouseButtonClick()
    {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                _coroutine = StartCoroutine(Increase(_delay));
            }
    }

    private IEnumerator Increase(float delay)
    {
        var wait = new WaitForSeconds (delay);
        
        while (enabled)
        {
            _value++;
            CounterChanged?.Invoke(_value);
            yield return wait;
        }
    }
}
