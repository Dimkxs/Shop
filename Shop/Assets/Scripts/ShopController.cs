using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;

public class ShopController : MonoBehaviour
{
    // JSON ���� � ������� � �������
    public TextAsset shopData;

    // ������� ��� ����������� �������
    public Transform shopTable;

    // ��������� ������
    public Inventory playerInventory;

    // ������ ������� � ��������
    private List<ShopItem> shopItems = new List<ShopItem>();

    void Start()
    {
        // �������� ������ � ������� �� JSON �����
        ShopData data = JsonUtility.FromJson<ShopData>(shopData.text);
        shopItems = data.items;

        // �������� ������� ��� ����������� �������
        foreach (ShopItem item in shopItems)
        {
            GameObject row = Instantiate(shopTable.gameObject, shopTable);
            row.GetComponent<ShopRow>().Initialize(item);
        }
    }

    // ����� ��� ������� ������
    public void BuyItem(ShopItem item)
    {
        // ��������, ���� �� ����� � ��������
        if (shopItems.Contains(item))
        {
            // �������� ������ �� ��������
            shopItems.Remove(item);

            // ���������� ������ � ��������� ������
            playerInventory.AddItem(item);

            // ���������� �������
            UpdateShopTable();
        }
    }

    // ����� ��� ���������� �������
    private void UpdateShopTable()
    {
        // ������� �������
        foreach (Transform child in shopTable)
        {
            Destroy(child.gameObject);
        }

        // �������� ����� �������
        foreach (ShopItem item in shopItems)
        {
            GameObject row = Instantiate(shopTable.gameObject, shopTable);
            row.GetComponent<ShopRow>().Initialize(item);
        }
    }
}

// ����� ��� �������� ������ � ������
[System.Serializable]
public class ShopItem
{
    public string name;
    public int price;
    public string description;
}

// ����� ��� �������� ������ � ��������
[System.Serializable]
public class ShopData
{
    public List<ShopItem> items;
}

// ����� ��� ����������� ������ � �������
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