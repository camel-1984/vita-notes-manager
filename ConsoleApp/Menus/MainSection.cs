namespace ConsoleApp.Menus;

public class MainSection : MenuSection
{
    public MainSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("=== MAIN MENU ===");
        Console.WriteLine("1. Notes");
        Console.WriteLine("2. Storage");
        Console.WriteLine("3. Exit");
        Console.WriteLine(new string('-', 30));
        Console.Write("Select option [1-3]: ");
    }
}