namespace ConsoleApp.Menus;

public class StorageSection : MenuSection
{
    public StorageSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("=== STORAGE ===");
        Console.WriteLine("1. Store Info");
        Console.WriteLine("2. Display Info");
        Console.WriteLine("3. Delete Info");
        Console.WriteLine("4. Exit to Main Menu");
        Console.WriteLine(new string('-', 30));
        Console.Write("Select option [1-4]: ");
    }
}