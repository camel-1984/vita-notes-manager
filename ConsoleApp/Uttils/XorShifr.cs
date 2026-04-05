namespace ConsoleApp.Uttils;

public class XorShifr : IShifr
{
    private readonly string Key = $"{Environment.MachineName}_{Environment.UserName}";
    
    public string Encrypt(string input)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = (char)(input[i] ^ Key[i % Key.Length]);
        }
        return new string(output);
    }

    public string Decrypt(string input)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = (char)(input[i] ^ Key[i % Key.Length]);
        }
        return new string(output);
    }
}