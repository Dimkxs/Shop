using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // ������ ��������� � ���������
    public List<InventoryItem> items = new List<InventoryItem>();

    // ������� ��� ����������� ���������
    public Transform inventoryTable;

    // ������������ ���������� ��������� � ���������
    public int maxItems = 20;

    // ����� ��� ���������� �������� � ���������
    public void AddItem(ShopItem item)
    {
        // ��������, ���� �� ����� � ���������
        if (items.Count < maxItems)
        {
            // �������� ������ �������� � ���������
            InventoryItem inventoryItem = new InventoryItem(item);
            items.Add(inventoryItem);

            // ���������� ������� ���������
            UpdateInventoryTable();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // ����� ��� �������� �������� �� ���������
    public void RemoveItem(InventoryItem item)
    {
        // �������� �������� �� ������
        items.Remove(item);

        // ���������� ������� ���������
        UpdateInventoryTable();
    }

    // ����� ��� ���������� ������� ���������
    private void UpdateInventoryTable()
    {
        // ������� �������
        foreach (Transform child in inventoryTable)
        {
            Destroy(child.gameObject);
        }

        // �������� ����� �������
        foreach (InventoryItem item in items)
        {
            GameObject row = Instantiate(inventoryTable.gameObject, inventoryTable);
            row.GetComponent<InventoryRow>().Initialize(item);
        }
    }
}

// ����� ��� �������� ������ � �������� � ���������
[System.Serializable]
public class InventoryItem
{
    public string name;
    public int quantity;
    public string description;

    public InventoryItem(ShopItem item)
    {
        name = item.name;
        quantity = 1;
        description = item.description;
    }
}

// ����� ��� ����������� ������ � ������� ���������
public class InventoryRow : MonoBehaviour
{
    public Text nameText;
    public Text quantityText;
    public Text descriptionText;

    public void Initialize(InventoryItem item)
    {
        nameText.text = item.name;
        quantityText.text = "x" + item.quantity.ToString();
        descriptionText.text = item.description;
    }
}