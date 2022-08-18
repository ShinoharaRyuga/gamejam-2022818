using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int nokori;
    [SerializeField] int noruma;
    [SerializeField] string clearscene;
    [SerializeField] string gameoverscene;
    bool game;

    public int Noruma { get => noruma; set => noruma = value; }
    public int Nokori { get => nokori; set => nokori = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(game)
        {
            if (nokori < 0)
            {
                GameClear();
            }
        }
    
    }
    void GameClear()
    {
        SceneManager.LoadScene(clearscene);
    }
    void GameOver()
    {
        SceneManager.LoadScene(gameoverscene);
    }
}
