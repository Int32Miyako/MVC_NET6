using Newtonsoft.Json;

namespace MVC_.NET6.Models;

public static class InitializeModels
{
    private static readonly Random _random = new Random();
    
    public static List<ItemModel> GetItems()
    {
        var items = Deserialization("dataBase.Items.json");
        
        return Input(Shuffle(items));
    }
    
    
    /// <summary>
    /// Алгоритм для перемешивания массива элементов
    /// </summary>
    /// <param name="array"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns> Массив элементов </returns>
    private static List<T> Shuffle<T>(List<T>? array)
    {
        var n = array!.Count;
        for (var i = n - 1; i > 0; i--)
        {
            var j = _random.Next(i + 1);

            (array[i], array[j]) = (array[j], array[i]);
        }
        
        return array;
    }
    
  

    private static List<ItemModel> Input(List<ItemModel> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            items[i].Id = i;
            items[i].Cost = _random.Next(0, Int32.MaxValue);
            items[i].Amount = _random.Next(0, 999);
            items[i].Action = "✎⌫";
        }

        return items;
    }
    
    private static List<ItemModel>? Deserialization(string path)
    {
        try
        {
            // Чтение содержимого файла в строку.
            var json = File.ReadAllText(path);

            // Десериализация JSON-строки в список объектов.
            var items = JsonConvert.DeserializeObject<List<ItemModel>>(json);
            
            return items;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}