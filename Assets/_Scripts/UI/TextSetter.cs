using TMPro;
using UnityEngine;

namespace UI
{
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] IntSO _value;
        private TMP_Text _tmpText;

        private void Start()
        {
            _tmpText = GetComponent<TMP_Text>();
            _value.Subscribe(UpdateText);
            UpdateText(_value.Value);
        }

        private void UpdateText(int valueValue)
        {
            _tmpText.text = valueValue.ToString();
        }

        private void OnValidate()
        {
            if (_tmpText == null)
                _tmpText = GetComponent<TMP_Text>();
        }
    }
}