using AvaloniaApplicationPracticeOne.Models;

namespace AvaloniaApplicationPracticeOne;

public class Service
{
    private static SavvateevContext? _db;
    
    public static SavvateevContext  GetDbContext()
    {
        if (_db == null)
        {
            _db = new SavvateevContext();
        }
        return _db;
    }
}