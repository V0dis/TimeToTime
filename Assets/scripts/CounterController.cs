using UnityEngine;
using System.Collections;
using TMPro;

public class CounterController : MonoBehaviour
{
    [SerializeField, Min(0)] private float _countDelay = 0.5f;
    [SerializeField] private TextMeshProUGUI _text;
    
    private int _currentCount; 
    private Coroutine _countingTask;
    
    private void Start()
    {
        _currentCount = 0;
        _countingTask = null;
    }

    private void Update()
    {
        HandleTimerInput();
    }
    
    private void OnDestroy()
    {
        if ((_countingTask == null) == false)
            StopCoroutine(_countingTask);
    }

    private void HandleTimerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_countingTask == null)
            {
                StartCounting();
            }
            else
            {
                PauseCounting();
            }
        }
    }

    private void StartCounting()
    {
        Debug.Log("Старт");

        _countingTask = StartCoroutine(IncrementCounter());
    }

    private void PauseCounting()
    {
        Debug.Log("Пауза");
        
        if ((_countingTask == null) == false)
        {
            StopCoroutine(_countingTask);
            
            _countingTask = null;
        }
    }
    
    private IEnumerator IncrementCounter()
    {
        while (enabled)
        {
            _currentCount++;

            _text.text = _currentCount.ToString();
            
            Debug.Log(_currentCount);
            
            yield return new WaitForSeconds(_countDelay);
        }
    }
}