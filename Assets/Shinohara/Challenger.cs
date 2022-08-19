using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenger : MonoBehaviour
{
    [SerializeField] BraveStamina[] _challengers = default;

    public BraveStamina[] Challengers { get => _challengers; set => _challengers = value; }
}
