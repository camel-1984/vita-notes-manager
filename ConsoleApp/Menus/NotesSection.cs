namespace ConsoleApp.Menus;

public class NotesSection : MenuSection
{
    public NotesSection(Stack<string> menuStack) : base(menuStack) { }

    public override void DisplaySection()
    {
        Console.WriteLine("=== NOTES ===");
        Console.WriteLine("1. Create Note");
        Console.WriteLine("2. Display Notes");
        Console.WriteLine("3. Delete Note");
        Console.WriteLine("4. Exit to Main Menu");
        Console.WriteLine(new string('-', 30));
        Console.Write("Select option [1-4]: ");
    }
}