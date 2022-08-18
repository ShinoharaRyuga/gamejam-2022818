using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;

    [SerializeField] int _nokori;
    [SerializeField] int _noruma;
    [SerializeField] string _clearscene;
    [SerializeField] string _gameoverscene;
    [SerializeField] Fade _fadeInPrefab = default;
    [SerializeField] Fade _fadeOutPrefab = default;

    bool _isGame = false;

    public int Noruma { get => _noruma; set => _noruma = value; }
    public int Nokori { get => _nokori; set => _nokori = value; }
    public bool IsGame { get => _isGame; set => _isGame = value; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            SceneManager.sceneLoaded += GameSceneLoad;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(_isGame)
        {
            if (_nokori < 0)
            {
                GameClear();
            }
        }
    }

    public void GameSceneChange()
    {
        Instantiate(_fadeInPrefab);
    }

    void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            Instantiate(_fadeOutPrefab);
        }
    }

    void GameClear()
    {
        SceneManager.LoadScene(_clearscene);
    }
    void GameOver()
    {
        SceneManager.LoadScene(_gameoverscene);
    }
}
