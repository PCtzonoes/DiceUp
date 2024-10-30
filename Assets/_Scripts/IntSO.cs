using System;
using Helper;
using Helper.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/IntSO")]
public class IntSO : AGenericEventListener<int>
{
    [SerializeField] private int _value;
    [SerializeField] private int _defaultValue;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            InvokeActions(_value);
        }
    }

    private void OnEnable()
    {
        Value = _defaultValue;
    }
}

