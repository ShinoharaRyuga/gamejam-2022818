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
    [SerializeField, Tooltip("勇者,商人,盗賊のプレハブをアタッチ")]
    BraveStamina[] _waitChallengers = default;
    [SerializeField, Tooltip("引き抜くスプライト")]
    FallChallenger[] _fallChallenger = default;

    Transform _spawnPoint = default;
    Transform _spwanPoint1 = default;
    /// <summary>現在の挑戦中の挑戦者 </summary>
    BraveStamina _currentChallenger = default;
    bool _isGame = false;

    public int Noruma { get => _noruma; set => _noruma = value; }
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
        if (_isGame)
        {
            if (_nokori <= 0)
            {
                GameClear();
                _isGame = false;
            }
        }
    }

    /// <summary>スタートボタンが押されたらフェードインオブジェクトを生成する </summary>
    public void GameSceneChange()
    {
        Instantiate(_fadeInPrefab);
    }

    /// <summary>残り人数を減らし、次の挑戦者を決める </summary>
    public FallChallenger ReduceChallenger()
    {
        _nokori--;
        // return SetNextChallenger();
        return null;
    }

    /// <summary>ランダムで次の挑戦者を決める </summary>
    public FallChallenger SetNextChallenger()
    {
        //var index = Random.Range(0, _challengers.Length);
        var index = 0;
        _currentChallenger = _waitChallengers[index];
        Instantiate(_currentChallenger, _spawnPoint.position, Quaternion.identity);
        var FallChallenger = Instantiate(_fallChallenger[0], _spwanPoint1.position, Quaternion.identity);
        Debug.Log(_waitChallengers[index].gameObject.name);

        return FallChallenger;
    }

    /// <summary>フェードアウトオブジェクトを生成する </summary>
    void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            Instantiate(_fadeOutPrefab);
            _spawnPoint = GameObject.Find("WaitSpawnPoint").transform;
            _spwanPoint1 = GameObject.Find("SpawnPoint").transform;
        }
    }

    void GameClear()
    {
        SceneManager.LoadScene("GameClearScene");
        Debug.Log("クリア");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
