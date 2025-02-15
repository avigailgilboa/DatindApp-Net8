// using System;

namespace API.Entities;

public class AppUser
{
    //שיניתי מIDSTOMG ל ID ואז ה ישר נחשב לפרימר קי
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    
}
