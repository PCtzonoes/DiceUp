using System;
using UnityEngine;
using UnityEngine.Assertions;
using Random = System.Random;

public class DiceBox : MonoBehaviour
{
    [SerializeField] private IntSO _luck;
    [SerializeField] private IntSO _enemyRoll;
    public Transform DiceSpawnPoint;
    public Dice Dice;

    private DateTime _lastRollTime;
    private bool CanRollDice => DateTime.UtcNow - _lastRollTime > TimeSpan.FromSeconds(1);

    private void Start()
    {
        _lastRollTime = DateTime.UtcNow.AddSeconds(-2);
    }

    public void RollDice()
    {
        if (!CanRollDice) return;

        _lastRollTime = DateTime.UtcNow;
        Dice.Rb.position = DiceSpawnPoint.position;
        Dice.Rb.rotation = DiceSpawnPoint.rotation;
        Dice.Roll();
        _enemyRoll.Value = _luck.Value + UnityEngine.Random.Range(1, 4);
    }

    private void FixedUpdate()
    {
        if (Dice.transform.position.y < -10)
        {
            ResetDice();
        }
    }

    private void ResetDice()
    {
        Dice.transform.position = DiceSpawnPoint.position;
        Dice.Rb.rotation = DiceSpawnPoint.rotation;
        Dice.Rb.velocity = Vector3.zero;
        Dice.Rb.angularVelocity = Vector3.zero;
        Dice.Rb.useGravity = false;
    }
}