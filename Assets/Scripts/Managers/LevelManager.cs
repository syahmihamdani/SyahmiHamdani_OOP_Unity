using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public Animator animator;
    void Awake()
    {
        animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Player.Instance.transform.position = new Vector3(0, -4.5f, 0); 
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadSceneAsync(sceneName));
                if (animator != null){
             animator.SetBool("transition", false);
         }
         
    }
}
