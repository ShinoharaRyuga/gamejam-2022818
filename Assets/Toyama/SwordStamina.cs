using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordStamina : MonoBehaviour
{
    [SerializeField] float _maxStamina = 0f;
    [SerializeField] float _addStamina = 1f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _reduceTime = 1f;
    [SerializeField] Slider sli;

    bool _dead = false;
    float _currentStamina = 0f;
    float _time = 0f;
    GameManager _gameManager = default;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _currentStamina = _maxStamina;
        sli.value = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_currentStamina < _maxStamina)
            {
                _currentStamina += _addStamina;
            }
        }
       
        if (_gameManager.IsGame)
        {
            _time += Time.deltaTime;

            if (_reduceTime < _time && 0 < _currentStamina)
            {
                _currentStamina -= _damage;
                _time = 0f;
                sli.value = (float)_currentStamina / (float)_maxStamina;
            }
            else if(_currentStamina <= 0 && !_dead)
            {
                _dead = true;
                _gameManager.GameOver();
            }
        }
    }
}
