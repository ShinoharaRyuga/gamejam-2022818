using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpInput : MonoBehaviour
{
    [SerializeField, Tooltip("���X�^�~�i")] int SoodSutamina;
    // Start is called before the first frame update
    void Start()
    {
       SoodSutamina = 70;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SoodSutamina += 1;
            Debug.Log("���X�^�~�i" + SoodSutamina);
          
        }
        if (SoodSutamina > 80)
        {
            SoodSutamina = 80;
        }
    }
}
