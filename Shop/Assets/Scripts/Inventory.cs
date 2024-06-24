using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // Список предметов в инвентаре
    public List<InventoryItem> items = new List<InventoryItem>();

    // Таблица для отображения инвентаря
    public Transform inventoryTable;

    // Максимальное количество предметов в инвентаре
    public int maxItems = 20;

    // Метод для добавления предмета в инвентарь
    public void AddItem(ShopItem item)
    {
        // Проверка, есть ли место в инвентаре
        if (items.Count < maxItems)
        {
            // Создание нового предмета в инвентаре
            InventoryItem inventoryItem = new InventoryItem(item);
            items.Add(inventoryItem);

            // Обновление таблицы инвентаря
            UpdateInventoryTable();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // Метод для удаления предмета из инвентаря
    public void RemoveItem(InventoryItem item)
    {
        // Удаление предмета из списка
        items.Remove(item);

        // Обновление таблицы инвентаря
        UpdateInventoryTable();
    }

    // Метод для обновления таблицы инвентаря
    private void UpdateInventoryTable()
    {
        // Очистка таблицы
        foreach (Transform child in inventoryTable)
        {
            Destroy(child.gameObject);
        }

        // Создание новой таблицы
        foreach (InventoryItem item in items)
        {
            GameObject row = Instantiate(inventoryTable.gameObject, inventoryTable);
            row.GetComponent<InventoryRow>().Initialize(item);
        }
    }
}

// Класс для хранения данных о предмете в инвентаре
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

// Класс для отображения строки в таблице инвентаря
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