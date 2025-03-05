using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}


// using API.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace API.Data
// {
//     public class DataContext : DbContext // שים לב לסימן ה-":"
//     {
//         public DataContext(DbContextOptions<DataContext> options) : base(options) // הוספת : base(options)
//         {
//         }

//         public DbSet<AppUser> Users { get; set; }
//     }
// }
