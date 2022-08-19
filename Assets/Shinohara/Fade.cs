using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    Text _startText = default;
    GameManager _gameManager = default;
    public void ThisDestroy()
    {
        Destroy(gameObject);
    }

    public void GameSceneChage()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOverSceneChage()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SetFirstChallenger()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager.SetNextChallenger();
        Debug.Log("呼ばれた");
    }

    public void GameStart()
    {
        _gameManager.IsGame = true;
        Debug.Log("ゲームスタート");
    }
}
