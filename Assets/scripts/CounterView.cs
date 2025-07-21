using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    public void Show(int count)
    {
        _text.text = count.ToString();

        Debug.Log(count);
    }
}