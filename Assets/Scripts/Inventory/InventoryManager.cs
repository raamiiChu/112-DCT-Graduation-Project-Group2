using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Inventory Manager in the scene");
        }

        instance = this;
    }

    public static InventoryManager GetInstance()
    {
        return instance;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItem()
    {
        // clean content before open
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemIcon.preserveAspect = true;
            obj.GetComponent<ItemController>().SetItem(item);
        }
    }
}
