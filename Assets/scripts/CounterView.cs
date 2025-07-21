using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += ChangedText;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangedText;
    }

    private void ChangedText(int count)
    {
        _text.text = count.ToString();
    }
}