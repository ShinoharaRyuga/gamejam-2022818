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

    GameManager _gameManager = default;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _currentStamina = _maxStamina;
        sli.value = 1;
    }

    void Update()
    {
        if (_gameManager.IsGame)
        {
            _time += Time.deltaTime;

            if (_nowTime < _time && 0 < _currentStamina)
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
}
