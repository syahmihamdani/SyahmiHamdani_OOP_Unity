using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton
public class LevelManager : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();

    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.enabled = true;

        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        animator.SetTrigger("StartTransition");


        Player.Instance.transform.position = new(0, -4.5f);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
