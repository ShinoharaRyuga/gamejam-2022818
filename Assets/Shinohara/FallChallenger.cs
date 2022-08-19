using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChallenger : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float[] _nextPosY = default;
    bool _isFall = true;
    int _currentIndex = 0;
    public bool IsFall { get => _isFall; set => _isFall = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _isFall = true;
            Debug.Log("true");
        }

        if (_isFall)
        {
            var pos = transform.position;
            pos.y -= _speed;
            transform.position = pos;

            if (transform.position.y <= _nextPosY[_currentIndex])
            {
                _isFall = false;
                _currentIndex++;
                Debug.Log("tru");
            }

            if (_nextPosY.Length <= _currentIndex)
            {
               
            }
        }
    }
}
