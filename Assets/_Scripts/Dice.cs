using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Text uiText;

    private Rigidbody _rigidbody;
    private bool _isRolling;

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

    public void Roll()
    {
        _isRolling = true;
    }

    private void FixedUpdate()
    {
        if (!_isRolling) return;

        if (_rigidbody.velocity.sqrMagnitude < 0.1f)
        {
            _isRolling = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            MoveSpawnPointToUpwardFace();
            uiText.transform.position = _spawnPoint.position;
        }
    }

    private void MoveSpawnPointToUpwardFace()
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

        var  cubeScale = transform.localScale;

        // Define the corresponding center positions for each face
        var faceCenterPositions = new Vector3[]
        {
            transform.position + transform.up * (cubeScale.y / 2), // Face 1
            transform.position - transform.up * (cubeScale.y / 2), // Face 6
            transform.position + transform.right * (cubeScale.x / 2), // Face 3
            transform.position - transform.right * (cubeScale.x / 2), // Face 4
            transform.position + transform.forward * (cubeScale.z / 2), // Face 2
            transform.position - transform.forward * (cubeScale.z / 2) // Face 5
        };

        // Find the face whose local up vector is closest to the world up vector
        float maxDot = -1f;
        int upwardFaceIndex = -1;
        for (int i = 0; i < faceUpVectors.Length; i++)
        {
            float dot = Vector3.Dot(faceUpVectors[i], Vector3.up);
            if (dot > maxDot)
            {
                maxDot = dot;
                upwardFaceIndex = i;
            }
        }

        // Move the spawn point to the center of the upward face
        if (upwardFaceIndex != -1)
        {
            _spawnPoint.position = faceCenterPositions[upwardFaceIndex];
        }
    }
}