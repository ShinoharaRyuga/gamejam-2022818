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
    [SerializeField, Tooltip("�E��,���l,�����̃v���n�u���A�^�b�`")]
    BraveStamina[] _challengers = default;
    /// <summary>���݂̒��풆�̒���� </summary>
    BraveStamina _currentChallenger = default;
    bool _isGame = false;

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

    /// <summary>�X�^�[�g�{�^���������ꂽ��t�F�[�h�C���I�u�W�F�N�g�𐶐����� </summary>
    public void GameSceneChange()
    {
        Instantiate(_fadeInPrefab);
    }

    /// <summary>�c��l�������炵�A���̒���҂����߂� </summary>
    public void ReduceChallenger()
    {
        _nokori--;
        SetNextChallenger();
    }

    /// <summary>�����_���Ŏ��̒���҂����߂� </summary>
    public void SetNextChallenger()
    {
        var index = Random.Range(0, _challengers.Length);
        _challengers[index] = _challengers[index + 1];
        _currentChallenger = _challengers[index];
        _currentChallenger.gameObject.SetActive(true);
        Instantiate(_currentChallenger);
        Debug.Log(_challengers[index].gameObject.name);
    }

    /// <summary>�t�F�[�h�A�E�g�I�u�W�F�N�g�𐶐����� </summary>
    void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            Instantiate(_fadeOutPrefab);
            var Brave = GameObject.Find("Brave");
            var Merchant = GameObject.Find("Merchant");

            _gameSceneChallengers[0] = Brave;
            _gameSceneChallengers[1] = Merchant;

            foreach (var c in _challengers)
            {
                c.gameObject.SetActive(false);
            }
        }
    }

    void GameClear()
    {
       SceneManager.LoadScene("GameClearScene");
        Debug.Log("�N���A");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
