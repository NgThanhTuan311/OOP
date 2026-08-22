using System;

public class UserAccount
{
    // 1. Private backing fields
    private string _password;
    private decimal _balance;

    // 2. AccountId - Init-Only Property
    public string AccountId { get; init; }

    // 3. Username - Auto-Implemented Property
    public string Username { get; set; }

    // 4. Password - Write-Only Property
    public string Password
    {
        set
        {
            _password = "[ENCRYPTED]_" + value;
        }
    }

    // 5. Balance - Full Property with Validation
    public decimal Balance
    {
        get
        {
            return _balance;
        }
        set
        {
            if (value >= 0)
            {
                _balance = value;
            }
            else
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
        }
    }

    // 6. IsVIP - Computed Read-Only Property
    public bool IsVIP
    {
        get => Balance >= 10000m;
    }

    // 7. CreatedDate - Get-Only Auto Property
    public DateTime CreatedDate { get; }

    // Constructor
    public UserAccount()
    {
        CreatedDate = DateTime.Now;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 1. Test Object Initialization
        UserAccount user = new UserAccount
        {
            AccountId = "ACC-99201",
            Username = "Alice_Code",
            Password = "SuperSecretPassword123"
        };

        // Không thể thay đổi AccountId sau khi tạo object
        // user.AccountId = "ACC-00000"; // Lỗi

        Console.WriteLine($"Account ID: {user.AccountId}");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Account Created: {user.CreatedDate}");

        // 2. Password chỉ SET, không GET
        // Console.WriteLine(user.Password); // Lỗi

        // 3. Test Balance
        Console.WriteLine("\n--- Testing Balance Updates ---");

        user.Balance = 5000m;

        Console.WriteLine($"Current Balance: {user.Balance:C}");

        user.Balance = -200m;

        Console.WriteLine(
            $"Current Balance after invalid attempt: {user.Balance:C}"
        );

        // 4. Test IsVIP
        Console.WriteLine($"\nIs VIP? {user.IsVIP}");

        user.Balance = 15000m;

        Console.WriteLine($"Updated Balance: {user.Balance:C}");
        Console.WriteLine($"Is VIP now? {user.IsVIP}");
    }
}
