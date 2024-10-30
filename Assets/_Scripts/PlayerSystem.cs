using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Not a real system, just a placeholder for the sake of the example.
/// </summary>
public class PlayerSystem : MonoBehaviour
{
    [SerializeField] private IntSO _luck;
    [SerializeField] private IntSO _fame;
    [SerializeField] private IntSO _diceDust;
    [SerializeField] private IntSO _diceRoll;
    [SerializeField] private IntSO _enemyRoll;

    [SerializeField] private TempText _text;

    private void Start()
    {
        _diceRoll.Subscribe(OnDiceRollEnd);
    }

    private void OnDiceRollEnd(int val)
    {
        if (val > _enemyRoll.Value)
        {
            _fame.Value += 10;
            _diceDust.Value += 10 + _enemyRoll.Value;
            _text.UpdateText("You won!");
        }
        else
        {
            _fame.Value -= 10;
            _text.UpdateText("You lost!");
        }
    }
}