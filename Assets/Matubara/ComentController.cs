using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComentController : MonoBehaviour
{
    [SerializeField] Text _coment;
    [SerializeField] int[] _stamina;
    public void coment(int n)
    {
        if (n >= _stamina[0])
        {
            _coment.text = "high";
        }
        else if (n > _stamina[1] && n < _stamina[0])
        {
            _coment.text = "mid";
        }
        else if (n > _stamina[2] && n < _stamina[1])
        {
            _coment.text = "low";
        }
        else
        {
            _coment.text = "very low";
        }
    }
}
