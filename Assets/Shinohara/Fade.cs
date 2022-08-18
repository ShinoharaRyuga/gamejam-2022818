using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
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
}
