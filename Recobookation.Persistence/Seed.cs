using Recobookation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recobookation.Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Books.Any()) return;

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Ołowiany Świt",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    PublishDate = DateTime.Parse("2013-04-26"),
                    Genre = "science-ficton",
                    Description = "Uniwersum S.T.A.L.K.E.R.a oczami Polaka – stara mleczarnia, martwy cieć, zapomniany kalendarz i wieża w środku lasu."
                },
                new Book
                {
                    Title = "C# 10 and .NET 6",
                    Author = "Mark J. Price",
                    Publisher = "Packt",
                    PublishDate = DateTime.Parse("2021-10-09"),
                    Genre = "Learning",
                    Description = "Modern Cross-Platform Development: Build apps, websites, and services with ASP.NET Core 6, Blazor, and EF Core 6 using Visual Studio 2022 and Visual Studio Code."
                },
                 new Book
                {
                    Title = "Suszonki",
                    Author = "Marrone Teresa",
                    Publisher = "Zwierciadło",
                    PublishDate = DateTime.Parse("2019-10-30"),
                    Genre = "Cooking",
                    Description = "Kompendium wiedzy na temat suszenia owoców warzyw i również mięsa."
                },
                 new Book
                {
                    Title = "Test",
                    Author = "Test",
                    Publisher = "Test",
                    PublishDate = DateTime.Parse("1998-01-01"),
                    Genre = "Test",
                    Description = "Test"
                }
            };
            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
        }
    }
}