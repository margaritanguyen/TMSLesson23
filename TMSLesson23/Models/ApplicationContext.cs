using Microsoft.EntityFrameworkCore;
using TMSLesson23.Models;

namespace TMSLesson23
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public ApplicationContext(DbContextOptions options)
        :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Благословение небожителей", Author = "Мосян Тунсю", Year = 2000 },
                new Book { Id = 2, Name = "Мара и Морок", Author = "Лия Арден", Year = 2014 },
                new Book { Id = 3, Name = "Королевство шипов и роз", Author = "Сара Маас", Year = 1987 },
                new Book { Id = 4, Name = "Змей и голубка", Author = "Шелби Махёрин", Year = 2022 }
            );
        }
    }
}