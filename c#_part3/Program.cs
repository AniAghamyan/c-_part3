using System;

public class CustomDictionary<TKey, TValue>
{
    private TKey[] keys;
    private TValue[] values;
    private int count;
    public CustomDictionary(int capacity)
    {
        keys = new TKey[capacity];
        values = new TValue[capacity];
        count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        if (count >= keys.Length)
        {
            Console.WriteLine("Dictionary capacity reached!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                Console.WriteLine("Key already exists!");
                return;
            }
        }

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public TValue GetValue(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                return values[i];
            }
        }
        throw new ArgumentException("Key not found");
    }

    public void Remove(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                for (int j = i; j < count - 1; j++)
                {
                    keys[j] = keys[j + 1];
                    values[j] = values[j + 1];
                }
                count--;
                return;
            }
        }
        Console.WriteLine("Key not found, nothing to remove.");
    }
    public bool ContainsKey(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i].Equals(key))
            {
                return true;
            }
        }
        return false;
    }
    public void Display()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Key: {keys[i]}, Value: {values[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        CustomDictionary<string, int> dictionary = new CustomDictionary<string, int>(5);

        dictionary.Add("apple", 1);
        dictionary.Add("banana", 2);
        dictionary.Add("cherry", 3);

        dictionary.Display();

        Console.WriteLine($"Value for 'banana': {dictionary.GetValue("banana")}");

        dictionary.Remove("banana");
        dictionary.Display();

        Console.WriteLine($"Contains 'apple': {dictionary.ContainsKey("apple")}");
        Console.WriteLine($"Contains 'banana': {dictionary.ContainsKey("banana")}");
    }
}
