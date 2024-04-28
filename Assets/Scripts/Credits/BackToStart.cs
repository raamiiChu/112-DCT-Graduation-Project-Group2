using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    [SerializeField] private float animationDuration = 8.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToStartScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ToStartScene()
    {
        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene("Start");
    }
}
