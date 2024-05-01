using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenToggle : MonoBehaviour
{
    private static BlackScreenToggle instance;

    [Header("Black Screen")]
    public GameObject blackScreen;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one BlackScreenToggle in the scene");
        }

        instance = this;
    }

    public static BlackScreenToggle GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBlackScreen()
    {
        blackScreen.SetActive(true);
    }

    public void HideBlackScreen()
    {
        blackScreen.SetActive(false);
    }
}
