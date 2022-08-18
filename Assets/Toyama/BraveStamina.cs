using UnityEngine;
using UnityEngine.UI;

public class BraveStamina : MonoBehaviour
{
    [SerializeField] float _maxStamina = 0f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _reduceTime = 1f;
     Slider sli;

    float _currentStamina = 0f;
    float _time = 0f;
    bool _isLose = false;
    GameManager _gameManager = default;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sli = GameObject.Find("BraveStamina").GetComponent<Slider>();
        _currentStamina = _maxStamina;
        sli.value = 1;
    }

    void Update()
    {
        if (_gameManager.IsGame)
        {
            _time += Time.deltaTime;

            if (_reduceTime < _time && 0 < _currentStamina)
            {
                _currentStamina -= _damage;
                _time = 0f;
                sli.value = (float)_currentStamina / (float)_maxStamina;
            }
            else if(_currentStamina <= 0 && !_isLose)
            {
                _isLose = true;
                _gameManager.ReduceChallenger();
                Debug.Log("•‰‚¯");
                return;
            }
        }
    }
}
