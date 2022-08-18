using UnityEngine;
using UnityEngine.SceneManagement;

public class LordScene : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        Debug.Log("Click");
        SceneManager.LoadScene(_sceneName);
    }
}
