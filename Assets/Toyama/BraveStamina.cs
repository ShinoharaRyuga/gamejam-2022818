using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BraveStamina : MonoBehaviour
{
    [SerializeField] float _maxStamina = 0f;
    [SerializeField] float _currentStamina = 0f;
    [SerializeField] float _time = 0f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _nowTime;
    [SerializeField] Slider sli;

    void Start()
    {
        _currentStamina = _maxStamina;
        sli.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_nowTime < _time)
        {
            _currentStamina -= _damage;
            _time = 0f;
            sli.value = (float)_currentStamina / (float)_maxStamina;
        }
        else
        {
            return;
        }
    }
}
