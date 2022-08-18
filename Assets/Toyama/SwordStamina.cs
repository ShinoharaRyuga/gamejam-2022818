using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStamina : MonoBehaviour
{
    [SerializeField] float _maxStamina = 0f;
    [SerializeField] float _currentStamina = 0f;
    [SerializeField] float _time = 0f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _nowTime;

    void Start()
    {
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_nowTime < _time)
        {
            _currentStamina -= _damage;
            _time = 0f;
        }
        else
        {
            return;
        }
    }
}
