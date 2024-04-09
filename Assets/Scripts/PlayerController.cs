using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontal;
    private float _vertical;
    private Vector3 _velocity;
    [SerializeField]private float _speed = 300f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _velocity = new Vector3(_horizontal, _rigidbody.velocity.y, _vertical).normalized;
        _rigidbody.AddForce(_velocity * _speed);
    }
}