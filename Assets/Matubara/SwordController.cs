using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    /// <summary>�ړ����������I�u�W�F�N�g</summary>
    [SerializeField] Transform _sword;
    Vector2 _pos;
    /// <summary>�I�u�W�F�N�g�̈ړ���</summary>
    [SerializeField] float _movement;
    float _timer;
    [SerializeField] float _foldingtime;
    void Update()
    {
        _timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        _pos = _sword.position;
        if (_timer < _foldingtime)
        {
            _pos.y += _movement;
        }
        else if (_timer > _foldingtime && _timer < _foldingtime * 2)
        {
            _pos.y -= _movement;
        }
        else
        {
            _timer = 0;
        }
        _sword.position = _pos;
    }
}
