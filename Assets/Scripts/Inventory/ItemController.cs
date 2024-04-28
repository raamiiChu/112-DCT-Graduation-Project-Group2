using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item item;
    private GameObject itemDescription;
    private GameObject itemImage;

    private int currIndex;

    // Start is called before the first frame update
    void Start()
    {
        var par = gameObject.transform.parent.parent.parent;

        itemDescription = par.Find("ItemDescription").gameObject;
        itemDescription.SetActive(false);

        itemImage = par.Find("itemImage").gameObject;
        itemImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // set image and resize
        var ItemDescriptionImage = itemDescription.GetComponent<Image>();
        ItemDescriptionImage.sprite = item.description;
        ItemDescriptionImage.SetNativeSize();

        // set position at top-left of ui
        ItemDescriptionImage.transform.position = gameObject.transform.position + new Vector3(-180f, 125f, 0f);

        itemDescription.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemDescription.SetActive(false);
    }

    public void SetItem(Item incomeItem)
    {
        item = incomeItem;
    }

    public void ShowImage()
    {
        Sprite[] images = item.images;

        if (images.Length == 0)
        {
            return;
        }

        Button nextImageButton = itemImage.transform.Find("NextImageButton").GetComponent<Button>();
        nextImageButton.onClick.RemoveAllListeners();
        nextImageButton.onClick.AddListener(ShowNextImage);

        currIndex = 0;
        itemImage.GetComponent<Image>().sprite = images[currIndex];
        itemImage.GetComponent<Image>().preserveAspect = true;
        itemImage.SetActive(true);
    }

    public void ShowNextImage()
    {
        Sprite[] images = item.images;
        int itemLength = images.Length;

        currIndex += 1;
        if (currIndex < itemLength)
        {
            itemImage.GetComponent<Image>().sprite = images[currIndex];
            itemImage.GetComponent<Image>().preserveAspect = true;
        }
        else
        {
            currIndex = 0;
            itemImage.SetActive(false);
        }
    }
}
