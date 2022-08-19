using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    /// <summary>�ړ����������I�u�W�F�N�g</summary>
    [SerializeField] [Tooltip("�ړ����������I�u�W�F�N�g")] Transform _go;
    Vector2 _pos;
    [SerializeField] [Tooltip("�ړ����x")] float _moveSpeed;
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
