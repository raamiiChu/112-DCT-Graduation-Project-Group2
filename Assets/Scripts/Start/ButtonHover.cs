using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite buttonNormal;
    [SerializeField] private Sprite buttonHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = buttonHover;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112, 135, 168, 255);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = buttonNormal;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }

}