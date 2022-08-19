using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    BraveStamina[] _challengers = default;
    /// <summary>現在の挑戦中の挑戦者 </summary>
    BraveStamina _currentChallenger = default;
    bool _isGame = false;
    Text _nokoriText = default;
    GameObject[] _gameSceneChallengers = new GameObject[3];
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
    public void ReduceChallenger()
    {
        _nokori--;
        _nokoriText.text = $"{_nokori}人";
        SetNextChallenger();
    }

    /// <summary>ランダムで次の挑戦者を決める </summary>
    public void SetNextChallenger()
    {
        foreach (var c in _gameSceneChallengers)
        {
            if (c != null)
            {
                c.gameObject.SetActive(false);
            }
        }

        var index = Random.Range(0, _challengers.Length);
        _currentChallenger = _challengers[index];
         _gameSceneChallengers[index].gameObject.SetActive(true);
        Instantiate(_currentChallenger);
        Debug.Log(_challengers[index].gameObject.name);
    }

    /// <summary>フェードアウトオブジェクトを生成する </summary>
    void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            Instantiate(_fadeOutPrefab);
            _nokoriText = GameObject.Find("nokoriText").GetComponent<Text>();
            var Brave = GameObject.Find("Brave");
            var Merchant = GameObject.Find("Merchant");
            var Thief = GameObject.Find("Thief");

            _gameSceneChallengers[0] = Brave;
            _gameSceneChallengers[1] = Merchant;
            _gameSceneChallengers[2] = Thief;


            Brave.gameObject.SetActive(false);
            Merchant.gameObject.SetActive(false);
            Thief.gameObject.SetActive(false);
        }
        else if (scene.name == "TitleScene")
        {
            _nokori = 10;
            var startButton = GameObject.Find("StartButton").GetComponent<Button>();
            startButton.onClick.AddListener(() => GameSceneChange());
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
