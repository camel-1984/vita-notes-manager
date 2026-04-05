namespace ConsoleApp.Menus;

public class Menu
{
    private readonly Stack<string> MenuStack;

    public Menu()
    {
        MenuStack = new();
    }

    public void Run()
    {
        Console.WriteLine();
        Console.WriteLine("=== VITA ===");
        Console.WriteLine("Welcome to Vita Notes Manager!");
        Console.WriteLine(new string('-', 40));
        MenuStack.Push("Main menu");

        Uttils.IShifr shifr = new Uttils.XorShifr();

        Options.NotesOptions notesOptions = new("Event.json", shifr); 
        Options.StorageOptions storageOptions = new("Storage.json", shifr);

        

        while (true)
        {

            Console.WriteLine();

            if (MenuStack.Count == 0)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Thank you for using Vita Notes Manager!");
                Console.WriteLine("=== VITA ===");
                break;
            }

            switch (MenuStack.Peek())
            {
                case "Exit":
                    MenuStack.Pop();
                    MenuStack.Pop();
                    break;

                case "Main menu":
                    MainSection mainSection = new(MenuStack);
                    mainSection.DisplaySection();
                    var optionMain = Console.ReadLine() ?? "";
                    mainSection.ParseOption<MainEnum>(optionMain);
                    break;

                case "Event":
                    NotesSection eventSection = new(MenuStack);
                    eventSection.DisplaySection();
                    var optionEvent = Console.ReadLine() ?? "";
                    eventSection.ParseOption<NotesEnum>(optionEvent);
                    break;

                case "TakeNode":
                    Console.WriteLine("=== CREATE NEW NOTE ===");
                    Console.Write("Enter note title: ");
                    var noteTitle = Console.ReadLine() ?? "";
                    Console.Write("Enter note content: ");
                    var noteContent = Console.ReadLine() ?? "";
                    notesOptions.AddNote(noteTitle, noteContent);
                    MenuStack.Pop();
                    break;

                case "ShowNodeList":
                    if (!notesOptions.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select note to display [number]: ");
                    var noteToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToShow, out int noteToShowInt) &&
                        notesOptions.InRange(noteToShowInt - 1))
                    {
                        notesOptions.DisplayNode(noteToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error: Invalid note selection");
                    }
                    MenuStack.Pop();
                    break;

                case "DeleteEventNode":
                    if (!notesOptions.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select note to delete [number]: ");
                    var noteToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(noteToDelete, out int notToDeleteInt) &&
                        notesOptions.InRange(notToDeleteInt - 1))
                    {
                        notesOptions.DeleteNode(notToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error: Invalid note selection");
                    }
                    MenuStack.Pop();
                    break;

                case "Storage":
                    StorageSection storageSection = new(MenuStack);
                    storageSection.DisplaySection();
                    var optionStorage = Console.ReadLine() ?? "";
                    storageSection.ParseOption<StorageEnum>(optionStorage);
                    break;

                case "Store":
                    storageOptions.AddStorageNode();
                    MenuStack.Pop();
                    break;

                case "ShowStorageList":
                    if (!storageOptions.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select record to display [number]: ");
                    var nodeToShow = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToShow, out int nodeToShowInt) &&
                        storageOptions.InRange(nodeToShowInt - 1))
                    {
                        storageOptions.DisplayNode(nodeToShowInt - 1);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error: Invalid record selection");
                    }
                    MenuStack.Pop();
                    break;

                case "DeleteStorageNode":
                    if (!storageOptions.DisplayNodeList())
                    {
                        MenuStack.Pop();
                        break;
                    }
                    Console.Write("Select record to delete [number]: ");
                    var nodeToDelete = Console.ReadLine() ?? "";

                    if (int.TryParse(nodeToDelete, out int nodeToDeleteInt) &&
                        storageOptions.InRange(nodeToDeleteInt - 1))
                    {
                        storageOptions.DeleteNode(nodeToDeleteInt - 1);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error: Invalid record selection");
                    }
                    MenuStack.Pop();
                    break;
            }
        }
    }
}