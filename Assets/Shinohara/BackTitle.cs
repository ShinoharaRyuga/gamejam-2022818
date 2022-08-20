using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Back());
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(5f); 
        SceneManager.LoadScene("TitleScene");
    }
}
