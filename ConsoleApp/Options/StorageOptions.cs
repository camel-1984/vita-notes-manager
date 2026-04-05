using ConsoleApp.Uttils;

namespace ConsoleApp.Options;

public class StorageOptions : Option<StorageOptions.StorageNode>
{
    public class StorageNode
    {
    [JsonPropertyName("date")]
    public DateTime CreationTime { get; set; }

    [JsonPropertyName("state")]
    private int state_;

    public int State
    {
        get => state_;
        set
        {
            if (value >= 1 && value <= 10)
            {
                state_ = value;
            }
            else
            {
                Console.WriteLine();
                throw new ArgumentException("Invalid state value");
            }
        }
    }
    public void Display()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"State: {State}/10.");
        Console.WriteLine(new string('-', 30));
    }

    public static StorageNode CreateStorageNode()
    {
        Console.WriteLine("=== CREATE STORAGE RECORD ===");

        var node = new StorageNode();

        Console.Write("Enter state [1-10]: ");
        var inputState = Console.ReadLine();

        if (int.TryParse(inputState, out int outState))
        {
            node.CreationTime = DateTime.Now;
            node.State = outState;
        }
        else
        {
            throw new ArgumentException("Invalid state value");
        }

        Console.WriteLine();
        Console.WriteLine("Record successfully created");
        return node;
    }        
    }
    
    public StorageOptions(string path, IShifr shifr) : base(path, shifr) { }

    public void AddStorageNode()
    {
        try
        {
            StorageNode node = StorageNode.CreateStorageNode();
            NodeList.Add(node);
            SaveNodes();
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public override bool DisplayNodeList()
    {
        if (NodeList.Count > 0)
        {
            Console.WriteLine("=== STORAGE INFO ===");
            for (int i = 0; i < NodeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Created: {NodeList[i].CreationTime:yyyy-MM-dd HH-mm-ss}");
            }
            Console.WriteLine(new string('-', 30));
            return true;
        }
        Console.WriteLine("No Info available");
        return false;
    }

    public override void DisplayNode(int index)
    {
        NodeList[index].Display();    
    }
}

