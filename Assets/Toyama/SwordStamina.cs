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
    Slider sli;

    bool _isFall = true;
    bool _dead = false;
    float _currentStamina = 0f;
    float _time = 0f;
    GameManager _gameManager = default;

    public float CurrentStamina { get => _currentStamina; set => _currentStamina = value; }
    public bool Dead { get => _dead; set => _dead = value; }

    void Start()
    {
        sli = GameObject.Find("SwordStamina").GetComponent<Slider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _currentStamina = _maxStamina;
        sli.value = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentStamina < _maxStamina)
            {
                _currentStamina += _addStamina;
                sli.value = (float)_currentStamina / (float)_maxStamina;
               
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
                Debug.Log("hit");
                _dead = true;
                _gameManager.GameOver();
            }

            if (_gameManager.Nokori == 1)
            {
                _damage = 12.5f;
                _addStamina = 1;
            }
        }

        Debug.Log(_currentStamina);
    }
}
