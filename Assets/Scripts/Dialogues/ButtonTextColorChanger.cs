using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonTextColorChanger : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
    }
}
