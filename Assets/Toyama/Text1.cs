using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text1 : MonoBehaviour
{
    [SerializeField] string _talks = "";
    [SerializeField] Text _textLabel;
    [SerializeField] float _nowTime = 1f;
    private float _time = 0;

    int _index = 0;
    private void Update()
    {
        _time += Time.deltaTime;

        if (_nowTime < _time && _index < _talks.Length)
        { 
            var str = _textLabel.text + _talks[_index].ToString();
            _textLabel.text = str;
            _index++;
            _time = 0f;
        }
    }
}
