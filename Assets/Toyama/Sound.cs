using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioClip _se;
    private AudioSource _Adi;

    void Start()
    {
        _Adi = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _Adi.PlayOneShot(_se);
        }
    }
}