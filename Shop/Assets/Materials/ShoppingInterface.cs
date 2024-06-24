using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ShoppingInterface : MonoBehaviour
{
    public Text moneyText;
    public Text smartphoneText;
    public Text laptopText;
    public Text wirelessText;

    void Start()
    {
        string json = @"
        {
            ""money"": 10000,
            ""smartphone"": {
                ""rating"": 4.5,
                ""name"": ""Smartpho"",
                ""cost"": 599.99,
                ""pieces"": 10,
                ""brand"": ""BrandX"",
                ""description"": ""High-end smartphone with advanced features.""
            },
            ""laptop"": {
                ""rating"": 4.7,
                ""name"": ""Laptop"",
                ""cost"": 999.99,
                ""pieces"": 5,
                ""brand"": ""BrandY"",
                ""description"": ""Powerful laptop for work and gaming.""
            },
            ""wireless"": {
                ""rating"": 4.8,
                ""name"": ""Wireless"",
                ""description"": ""Premium wireless Headphon headphones with Fiece noise-cancellation.""
            }
        }
        ";

        ShoppingData data = JsonConvert.DeserializeObject<ShoppingData>(json);

        moneyText.text = $"Money: {data.money}";

        smartphoneText.text = $"{data.smartphone.rating}\n{data.smartphone.name}\nCosts {data.smartphone.cost}\nPiece\n{data.smartphone.pieces}\n{data.smartphone.brand}\n{data.smartphone.description}\nBUY";

        laptopText.text = $"{data.laptop.rating}\n{data.laptop.name}\nCosts {data.laptop.cost}\nPiece\n{data.laptop.pieces}\n{data.laptop.brand}\n{data.laptop.description}";

        wirelessText.text = $"{data.wireless.rating}\n{data.wireless.name}\n{data.wireless.description}\nBUY";
    }
}

public class ShoppingData
{
    public int money { get; set; }
    public Smartphone smartphone { get; set; }
    public Laptop laptop { get; set; }
    public Wireless wireless { get; set; }
}

public class Smartphone
{
    public double rating { get; set; }
    public string name { get; set; }
    public double cost { get; set; }
    public int pieces { get; set; }
    public string brand { get; set; }
    public string description { get; set; }
}

public class Laptop
{
    public double rating { get; set; }
    public string name { get; set; }
    public double cost { get; set; }
    public int pieces { get; set; }
    public string brand { get; set; }
    public string description { get; set; }
}

public class Wireless
{
    public double rating { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}