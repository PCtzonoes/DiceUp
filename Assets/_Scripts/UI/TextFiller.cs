using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextFiller : MonoBehaviour
    {
        [SerializeField] IntSO _value;
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _value.Subscribe(UpdateText);
            UpdateText(_value.Value);
        }

        private void UpdateText(int valueValue)
        {
            _text.text = $"{gameObject.name}: {valueValue}";
        }

        private void OnDestroy()
        {
            _value.Unsubscribe(UpdateText);
        }

        private void OnValidate()
        {
            if (_text == null)
                _text = GetComponent<TMP_Text>();

            if (_value == null)
                Debug.LogError("Value is null", this);
        }
    }
}