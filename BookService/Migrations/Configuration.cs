namespace BookService.Migrations
{
    using BookService.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookServiceContext context)
        {
            context.Autores.AddOrUpdate(a => a.Id,
                new Autor() { Id = 1, Nome = "J.R.R. Tolkien" },
                new Autor() { Id = 2, Nome = "Philip K. Dick" },
                new Autor() { Id = 3, Nome = "Stephen King" }
                );

            context.Livros.AddOrUpdate(l => l.Id,
                new Livro() { Id = 1, Titulo = "A Sociedade do Anel", Ano = 1954,
                    AutorId = 1, Preco = 9.99M, Genero = "Fantasia" },
                new Livro() { Id = 2, Titulo = "O Homem do Castelo Alto", Ano = 1962,
                    AutorId = 2, Preco = 9.99M, Genero = "Ficção Cientifica" },
                new Livro() { Id = 3, Titulo = "O Iluminado", Ano = 1977,
                    AutorId = 3, Preco = 9.99M, Genero = "Terror" },
                new Livro() { Id = 4, Titulo = "As Duas Torres", Ano = 1954,
                    AutorId = 1, Preco = 9.99M, Genero = "Fantasia" }
                );
        }
    }
}
