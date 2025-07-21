using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _countDelay = 0.5f;
    [SerializeField] private CounterView _counterView;
    
    private Coroutine _countingTask;
    
    public int _currentCount { get; private set; } 
    
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

    public void HandleTimerInput()
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
        _countingTask = StartCoroutine(IncrementCounter());
    }

    private void PauseCounting()
    {
        if ((_countingTask == null) == false)
        {
            StopCoroutine(_countingTask);
            
            _countingTask = null;
        }
    }
    
    private IEnumerator IncrementCounter()
    {
        WaitForSeconds wait = new WaitForSeconds(_countDelay);

        while (enabled)
        {
            _currentCount++;
            
            _counterView.Show(_currentCount);
            
            yield return wait;
        }
    }
}