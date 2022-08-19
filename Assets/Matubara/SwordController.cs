using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    /// <summary>移動させたいオブジェクト</summary>
    [SerializeField] [Tooltip("移動させたいオブジェクト")] Transform _go;
    Vector2 _pos;
    [SerializeField] [Tooltip("移動速度")] float _moveSpeed;
    [SerializeField] Transform[] _targets;
    [SerializeField] float _stoppingDistance;
    int _currentTargetIndex;
    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _targets[_currentTargetIndex % _targets.Length].position);
        if (distance > _stoppingDistance)
        {
            Vector3 dir = (_targets[_currentTargetIndex % _targets.Length].transform.position - transform.position).normalized * _moveSpeed;
            _go.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _currentTargetIndex++;
        }
    }
}
