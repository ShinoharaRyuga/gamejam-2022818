using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tukuru : MonoBehaviour
{
    [SerializeField] GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tukuro()
    {
        Instantiate(a);
    }
}
