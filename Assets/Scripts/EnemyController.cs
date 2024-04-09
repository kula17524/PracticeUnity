using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _player;
    private Vector3 _direction;
    [SerializeField]private float _moveSpeed = 300f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _direction = (_player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(_direction * _moveSpeed);
        Debug.Log(_direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
