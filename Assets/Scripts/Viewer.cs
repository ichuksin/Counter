using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += DispalyCounter;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= DispalyCounter;
    }

    private void DispalyCounter(int number)
    {
        _text.text = number.ToString();
    }
}
