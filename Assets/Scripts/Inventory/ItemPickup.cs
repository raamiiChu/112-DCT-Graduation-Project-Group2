using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Item additionalItem;

    public void Pickup()
    {
        InventoryManager.GetInstance().Add(item);

        if (additionalItem)
        {
            InventoryManager.GetInstance().Add(additionalItem);
        }

        // hide gameObject
        gameObject.SetActive(false);
        gameObject.transform.Find("Trigger").gameObject.SetActive(false);
    }
}
