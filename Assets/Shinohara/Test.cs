using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject _t;
    [SerializeField] Transform _point;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(_t, _point.position, Quaternion.identity);
        }
    }
}
