using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Api.Database;
using Microsoft.Extensions.DependencyInjection;

namespace graphQL2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var authorDbEntry = context.Authors.Add(
                  new Author
                  {
                      Name = "Kelly Vargas",
                  }
                );

                context.SaveChanges();

                context.Books.AddRange(
                  new Book
                  {
                      Name = "Divine Comedy",
                      Published = true,
                      AuthorId = authorDbEntry.Entity.Id,
                      Genre = "Poems"
                  },
                  new Book
                  {
                      Name = "The Open Veins of Latin America",
                      Published = true,
                      AuthorId = authorDbEntry.Entity.Id,
                      Genre = "Poems"
                  },
                  new Book
                  {
                      Name = "The Stranger",
                      Published = true,
                      AuthorId = authorDbEntry.Entity.Id,
                      Genre = "Philosophy"
                  }
                );
             
                context.SaveChanges();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
