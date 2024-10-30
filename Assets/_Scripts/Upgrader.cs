using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] private IntSO _luck;
    [SerializeField] private IntSO _diceDust;
    [SerializeField] private TMP_Text _text;

    private int _upgradeCost = 10;

    public void Upgrade()
    {
        if (_diceDust.Value < _upgradeCost) return;

        _luck.Value += 10;
        _diceDust.Value -= _upgradeCost;
        _upgradeCost += 10 + _luck.Value / 2;
        _text.text = $"Upgrade: {_upgradeCost}";
    }
}