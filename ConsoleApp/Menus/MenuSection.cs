namespace ConsoleApp.Menus;

public abstract class MenuSection
{
    protected readonly Stack<string> MenuStack;

    public MenuSection(Stack<string> menuStack)
    {
        MenuStack = menuStack;
    }

    public void ParseOption<T>(string optionKey) where T : Enum
    {
        if (int.TryParse(optionKey, out int optionOut) && Enum.IsDefined(typeof(T), optionOut))
        {
            var selectedOption = (T)Enum.ToObject(typeof(T), optionOut);
            MenuStack.Push(selectedOption.ToString());
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Error: Invalid option selected");
        }
    }

    public abstract void DisplaySection();
}

public enum MainEnum
{
    Event = 1,
    Storage = 2,
    Exit = 3
}
public enum NotesEnum
{
    TakeNode = 1,
    ShowNodeList = 2,
    DeleteEventNode = 3,
    Exit = 4
}

public enum StorageEnum
{
    Store = 1,
    ShowStorageList = 2,
    DeleteStorageNode = 3,
    Exit = 4
}
