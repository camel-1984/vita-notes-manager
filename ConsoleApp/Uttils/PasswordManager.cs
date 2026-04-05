namespace ConsoleApp.Uttils;

public class PasswordManager
{
    [JsonIgnore]
    private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Props/Password.json");

    [JsonIgnore]
    private readonly JsonSerializerOptions option = new() { WriteIndented = true };

    [JsonPropertyName("Hash")]
    [JsonInclude]
    private string? Hash { get; set; }

    [JsonPropertyName("LastEnter")]
    [JsonInclude]
    private DateTime? LastEnter { get; set; }

    [JsonIgnore]
    private readonly IShifr? _shifr;

    public PasswordManager(IShifr shifr)
    {
        _shifr = shifr;
        EnsureDirectoryExists();
    }

    public PasswordManager()
    {
        EnsureDirectoryExists();
    }

    private void EnsureDirectoryExists()
    {
        try
        {
            string directory = Path.GetDirectoryName(FilePath)!;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"Directory created: {directory}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating directory: {ex.Message}");
            throw;
        }
    }

    private void LoadFile()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                Hash = null;
                LastEnter = null;
                return;
            }

            var encryptedJson = File.ReadAllText(FilePath);
            var json = encryptedJson;

            if (_shifr is not null && !string.IsNullOrEmpty(encryptedJson))
            {
                json = _shifr.Decrypt(encryptedJson);
            }

            var loadedObj = JsonSerializer.Deserialize<PasswordManager>(json) ?? this;
            
            Hash = loadedObj.Hash;
            LastEnter = loadedObj.LastEnter;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading password file: {ex.Message}");
            Hash = null;
            LastEnter = null;
        }
    }

    private void SaveFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(this, option);
            var encryptedJson = json;

            if (_shifr is not null)
            {
                encryptedJson = _shifr.Encrypt(json);
            }

            File.WriteAllText(FilePath, encryptedJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving password file: {ex.Message}");
            throw;
        }
    }

    private string GivePassword()
    {
        Console.WriteLine();
        Console.Write("Enter password: ");
        return PasswordProcessing();
    }

    private void SetPassword()
    {
        Console.WriteLine();
        Console.Write("Enter new password: ");
        string settedPassword = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(settedPassword))
        {
            Console.WriteLine("Password cannot be empty");
            return;
        }

        Hash = HashPassword(settedPassword);
        LastEnter = DateTime.Now;
        
        SaveFile();
    }

    private string PasswordProcessing()
    {
        string password = "";
        ConsoleKeyInfo key = Console.ReadKey(true);

        while (key.Key != ConsoleKey.Enter)
        {
            if (key.Key != ConsoleKey.Backspace)
            {
                password += key.KeyChar;
                Console.Write('*');
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Remove(password.Length - 1);
                Console.Write("\b \b");
            }
            key = Console.ReadKey(true);
        }
        return password;
    }

    private static string HashPassword(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public void PasswordCheck()
    {
        try
        {
            LoadFile(); 

            if (Hash is not null)
            {
                while (true)
                {
                    string givenPassword = GivePassword();
                    if (HashPassword(givenPassword) == Hash)
                    {
                        LastEnter = DateTime.Now;
                        SaveFile();
                        Console.WriteLine();
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Wrong password");
                }
            }
            else
            {
                SetPassword();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Password check error: {ex.Message}");
        }
    }
}