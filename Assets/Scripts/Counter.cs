using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _delay = 0.5f;
    private int _counter = 0;
    private bool isStarted = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isStarted)
            {
                isStarted = false;
                StopAllCoroutines();
            }
            else
            {
                isStarted = true;
                StartCoroutine(Timer(_delay));
            }
        }
    }

    private IEnumerator Timer(float delay)
    {
        var wait = new WaitForSeconds (delay);
        
        while (true)
        {
            DispalyCounter(_counter);
            _counter++;
            yield return wait;
        }
    }
    
    private void DispalyCounter(int i)
    {
        _text.text = i.ToString();  
    }
}
