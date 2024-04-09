using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    [SerializeField]private Vector3 _offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = this._player.transform.position + _offset;
    }
}
