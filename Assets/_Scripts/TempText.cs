using System;
using TMPro;
using UnityEngine;

public class TempText : MonoBehaviour
{
    private TMP_Text _text;
    private DateTime _lastUpdate;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
        _lastUpdate = DateTime.UtcNow;
    }

    private void Update()
    {
        if (DateTime.UtcNow - _lastUpdate > TimeSpan.FromSeconds(1.5f))
        {
            _text.text = string.Empty;
        }
    }
}