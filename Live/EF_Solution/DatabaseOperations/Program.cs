using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DatabaseOperations;

internal class Program
{
    private static string conStr = "Data Source=.\\SqlExpress;Initial Catalog=ShopDB;Persist Security Info=False;User ID=sa;Password=Test_1234567;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        var bld = new DbContextOptionsBuilder();
        bld.UseSqlServer(conStr, opts => {
            opts.MinBatchSize(64);
            
        });
        bld.LogTo(Console.WriteLine);

        var context = new ShopContext(bld.Options);
        //context.Database.EnsureCreated();

        //Brand b = new Brand { Name = "Sony", Website = "www.sony.nl" };
        //context.Brands.Add(b);

        //foreach(var item in context.ChangeTracker.Entries())
        //{ 
        //    Console.WriteLine(item.State);
        //    Console.WriteLine(item.CurrentValues[nameof(b.Name)]);
        //   // Console.WriteLine(item.OriginalValues[nameof(b.Name)]);
        //}

        //context.SaveChanges();

        var b = context.Brands.AsNoTracking().FirstOrDefault();
        b.Name = "Technics";

        foreach (var item in context.ChangeTracker.Entries())
        {
            Console.WriteLine(item.State);
            Console.WriteLine(item.CurrentValues[nameof(b.Name)]);
            Console.WriteLine(item.OriginalValues[nameof(b.Name)]);
        }

        //var state = context.Brands.Entry(b);
        //state.State = EntityState.Deleted;

        Console.ReadLine();
        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine(ex);

        }
        

        Console.WriteLine("Done!");
        Console.ReadLine();
    }
}
