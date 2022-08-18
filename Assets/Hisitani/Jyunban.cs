using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jyunban : MonoBehaviour
{
    [SerializeField]int jyun = 0;
    int co = 0;
    int[] kiroku = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i>kiroku.Length;)
        {
            jyun = Random.Range(1, 4);
            kiroku[i] = jyun;
            i++;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int x = 0;x>kiroku.Length;)
        {
            if (Input.GetKey(KeyCode.A) && kiroku[x] == 1)
            {
                x++;
            }
            if (Input.GetKey(KeyCode.W) && kiroku[x] == 2)
            {
                x++;
            }
            if (Input.GetKey(KeyCode.D) && kiroku[x] == 3)
            {
                x++;
            }
            if (Input.GetKey(KeyCode.S) && kiroku[x] == 4)
            {
                x++;
            }
        }
        Start();
    }

    
}
