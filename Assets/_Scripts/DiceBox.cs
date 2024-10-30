using System;
using UnityEngine;
using UnityEngine.Assertions;
using Random = System.Random;

public class DiceBox : MonoBehaviour
{
    public Transform DiceSpawnPoint;
    public Dice Dice;

    private DateTime _lastRollTime;
    private bool CanRollDice => DateTime.UtcNow - _lastRollTime > TimeSpan.FromSeconds(1);

    private void Start()
    {
        _lastRollTime = DateTime.UtcNow.AddSeconds(-2);
        RollDice();
    }

    public void RollDice()
    {
        if (!CanRollDice) return;

        Dice.Rb.useGravity = true;
        Dice.Rb.position = DiceSpawnPoint.position;
        Dice.Rb.rotation = DiceSpawnPoint.rotation;
        Dice.Rb.velocity = Vector3.zero;
        Dice.Rb.angularVelocity = Vector3.zero;
        Dice.Rb.AddForce(transform.up * -2, ForceMode.Impulse);
        Dice.Rb.AddForce(UnityEngine.Random.onUnitSphere * 2, ForceMode.Impulse);
        Dice.Rb.AddTorque(UnityEngine.Random.insideUnitSphere * 10, ForceMode.Impulse);
        _lastRollTime = DateTime.UtcNow;
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