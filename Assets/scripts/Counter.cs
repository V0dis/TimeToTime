using System;
using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _countDelay = 0.5f;
    [SerializeField] private InputReader _inputReader;
    
    private Coroutine _countingTask;
    private int _currentCount;
    
    public event Action<int> CountChanged;
    
    private void Start()
    {
        _currentCount = 0;
        _countingTask = null;
    }

    private void OnEnable()
    {
        _inputReader.LeftMouseClicked += HandleTimer;
    }
    
    private void OnDisable()
    {
        _inputReader.LeftMouseClicked -= HandleTimer;
    }
    
    public void HandleTimer()
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

    private void StartCounting()
    {
        _countingTask = StartCoroutine(IncrementCounter());
    }

    private void PauseCounting()
    {
        if (_countingTask != null)
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
            
            CountChanged?.Invoke(_currentCount);
            
            yield return wait;
        }
    }
}
