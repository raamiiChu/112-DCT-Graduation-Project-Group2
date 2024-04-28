using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialogueImage : MonoBehaviour
{
    private static ShowDialogueImage instance;
    private Transform mainContent;
    public Sprite[] mainImages;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Show Dialogue Image in the scene");
        }

        instance = this;
    }

    public static ShowDialogueImage GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        mainContent = gameObject.transform.Find("MainContent");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMainImage(int mainImageIndex)
    {
        var mainContentImage = mainContent.GetComponent<Image>();
        mainContentImage.sprite = mainImages[mainImageIndex];
        mainContentImage.preserveAspect = true;
        gameObject.SetActive(true);
    }

    public void HideMainImage()
    {
        gameObject.SetActive(false);
    }
}
