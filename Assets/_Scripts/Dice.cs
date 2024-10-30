using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] IntSO _diceResult;
    [SerializeField] IntSO Luck;

    private Coroutine _coroutine;
    private bool _isRolling = false;
    private Rigidbody _rigidbody;

    public Rigidbody Rb => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.mass = 8f;
        _rigidbody.drag = 0.1f;
        _rigidbody.angularDrag = 0.075f;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

// Dice.cs
    public void Roll()
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.AddForce(transform.up * -20 + Vector3.forward * 15, ForceMode.Impulse);
        _rigidbody.AddForce(UnityEngine.Random.onUnitSphere * 20, ForceMode.Impulse);
        _rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere * 100, ForceMode.Impulse);
        _isRolling = true;
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(CheckVelocity());
    }

    private IEnumerator CheckVelocity()
    {
        yield return new WaitForSeconds(1f);

        while (_isRolling)
        {
            if (_rigidbody.velocity.sqrMagnitude < 0.1f)
            {
                Debug.Log("Dice stopped rolling");
                _isRolling = false;
                RollValue();
            }

            yield return null; // Check again in the next frame
        }
    }

    private void RollValue()
    {
        // Define the local up vectors for each face of the dice
        var faceUpVectors = new Vector3[]
        {
            transform.up, // Face 1
            -transform.up, // Face 6
            transform.right, // Face 3
            -transform.right, // Face 4
            transform.forward, // Face 2
            -transform.forward // Face 5
        };

        //find the top face then using luck value to improve the _diceResult
        var maxDot = -1f;
        var topFace = 0;
        for (var i = 0; i < faceUpVectors.Length; i++)
        {
            var dot = Vector3.Dot(faceUpVectors[i], Vector3.up);
            if (dot > maxDot)
            {
                maxDot = dot;
                topFace = i;
            }
        }

        Debug.Log($"Top face: {topFace + 1}");

        _diceResult.Value = topFace + 1 + Luck.Value;
        Debug.Log($"Dice result: {_diceResult.Value}");
    }
}