using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]private GameObject _enemy;
    [SerializeField]private float _distance = 50.0f;
    [SerializeField]private float _spawnTime = 1.0f;
    private GameObject _player;
    private float _px;
    private float _pz;
    private float _angle;
    private Vector2 _circlePosition;
    private Vector3 _spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while(true) {
            /* // 距離がぴったり 50 の位置に Enemy を生成する場合
            // Player の座標から _distance 離れた座標 ( 円周上の座標 ) からランダムに 1 点指定
            _angle = Random.Range(0, 360);
            _px = Mathf.Cos(_angle * Mathf.Deg2Rad) * _distance + _player.transform.position.x;
            _pz = Mathf.Sin(_angle * Mathf.Deg2Rad) * _distance + _player.transform.position.z;
            _spawnPosition = new Vector3(_px, _player.transform.position.y, _pz);
            */

            // 距離が 50 以内の円内に Enemy を生成する場合
            // 半径 50 の円の中の点を 1 点ランダムに指定
            _circlePosition = Random.insideUnitCircle * _distance;
            _spawnPosition = new Vector3(_circlePosition.x, 0, _circlePosition.y) + _player.transform.position;

            // Enemy を生成
            Instantiate(_enemy, _spawnPosition, Quaternion.identity); 
            // 1 秒待機
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
