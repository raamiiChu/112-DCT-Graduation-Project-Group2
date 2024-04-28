using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartSceneManager : MonoBehaviour
{
    [Header("Scene Transition")]
    [SerializeField] Animator transition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        StartCoroutine(SceneTransition("CreateSystem"));
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        // play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        // load
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}