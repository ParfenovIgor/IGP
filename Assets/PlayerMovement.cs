using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    public float JumpVelocity = 10;
    public static int Score = 0; // The total number of collected coins

    private int _directionIndex;
    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable() {
        var velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private void FixedUpdate() {
        var velocity = _directionIndex == 0 ? Vector3.forward : Vector3.right;
        velocity *= Speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _directionIndex = _directionIndex == 0 ? 1 : 0;
        }
        if (Input.GetButtonDown("Jump")) {
            var velocity = _rigidbody.velocity;
            velocity.y = JumpVelocity;
            _rigidbody.velocity = velocity;
        }
    }
}
