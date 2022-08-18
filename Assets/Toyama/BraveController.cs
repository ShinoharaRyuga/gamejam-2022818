using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            Debug.Log("1");
        }
        if (Input.GetButtonDown("B"))
        {
            Debug.Log("2");
        }
        if (Input.GetButtonDown("Y"))
        {
            Debug.Log("3");
        }
        if (Input.GetButtonDown("X"))
        {
            Debug.Log("4");
        }
        if (Input.GetButtonDown("LB"))
        {
            Debug.Log("5");
        }
        if (Input.GetButtonDown("RB"))
        {
            Debug.Log("6");
        }
        float tri = Input.GetAxis("LT_RT");
        if (tri > 0)
        {
            Debug.Log("L trigger:" + tri);
        }
        else if (tri < 0)
        {
            Debug.Log("R trigger:" + tri);
        }
        else
        {
            return;
        }
    }
}
