using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;

public class ShopController : MonoBehaviour
{
    // JSON файл с данными о товарах
    public TextAsset shopData;

    // Таблица для отображения товаров
    public Transform shopTable;

    // Инвентарь игрока
    public Inventory playerInventory;

    // Список товаров в магазине
    private List<ShopItem> shopItems = new List<ShopItem>();

    void Start()
    {
        // Загрузка данных о товарах из JSON файла
        ShopData data = JsonUtility.FromJson<ShopData>(shopData.text);
        shopItems = data.items;

        // Создание таблицы для отображения товаров
        foreach (ShopItem item in shopItems)
        {
            GameObject row = Instantiate(shopTable.gameObject, shopTable);
            row.GetComponent<ShopRow>().Initialize(item);
        }
    }

    // Метод для покупки товара
    public void BuyItem(ShopItem item)
    {
        // Проверка, есть ли товар в магазине
        if (shopItems.Contains(item))
        {
            // Удаление товара из магазина
            shopItems.Remove(item);

            // Добавление товара в инвентарь игрока
            playerInventory.AddItem(item);

            // Обновление таблицы
            UpdateShopTable();
        }
    }

    // Метод для обновления таблицы
    private void UpdateShopTable()
    {
        // Очистка таблицы
        foreach (Transform child in shopTable)
        {
            Destroy(child.gameObject);
        }

        // Создание новой таблицы
        foreach (ShopItem item in shopItems)
        {
            GameObject row = Instantiate(shopTable.gameObject, shopTable);
            row.GetComponent<ShopRow>().Initialize(item);
        }
    }
}

// Класс для хранения данных о товаре
[System.Serializable]
public class ShopItem
{
    public string name;
    public int price;
    public string description;
}

// Класс для хранения данных о магазине
[System.Serializable]
public class ShopData
{
    public List<ShopItem> items;
}

// Класс для отображения строки в таблице
public class ShopRow : MonoBehaviour
{
    public Text nameText;
    public Text priceText;
    public Text descriptionText;

    public void Initialize(ShopItem item)
    {
        nameText.text = item.name;
        priceText.text = item.price.ToString();
        descriptionText.text = item.description;
    }
}