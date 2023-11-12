using Microsoft.EntityFrameworkCore;
using System.Data;
using UrlShortener.entities;
using UrlShorter.Entities;
using UrlShorter.Models.Enum;

namespace UrlShorter.Data
{
    public class URLShortContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<User> Users { get; set; }


        public URLShortContext(DbContextOptions<URLShortContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Categoria Trabajo = new Categoria()
            {
                Id = 1,
                Name = "Trabajo"
            };
            Categoria Diversion = new Categoria()
            {
                Id = 2,
                Name = "Diversion"
            };
            User Usuario1 = new User()
            {
                Id = 1,
                Name = "Pancho",
                Password = "password",
                RolUser = Role.Admin

            };

            User Usuario2 = new User()
            {
                Id = 2,
                Name = "Jose luis",
                Password = "password",
                RolUser = Role.User

            };

            User Usuario3 = new User()
            {
                Id = 3,
                Name = "Guest",
                Password = "password",
                RolUser = Role.Guest

            };

            Url url = new Url()
            {
                Id = 1,
                UrlShort = "llolo",
                UrlLong = "Lafsdfsft",
                contador = 0,
                IdCategoria = Trabajo.Id,
                IdUser = Usuario1.Id
            };
            Url url1 = new Url()
            {
                Id = 2,
                UrlShort = "Karen baila piola",
                UrlLong = "serdgrgfd",
                contador = 1,
                IdCategoria = Diversion.Id,
                IdUser = Usuario2.Id

            };

            Url url2 = new Url()
            {
                Id = 3,
                UrlShort = "asddsadsa",
                UrlLong = "sdsdsdsdauuuu",
                contador = 2,
                IdCategoria = Diversion.Id,
                IdUser = Usuario2.Id
            };

            modelBuilder.Entity<Url>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.IdUser);
            modelBuilder.Entity<Url>()
            .HasOne(c => c.Categoria)
            .WithMany()
            .HasForeignKey(c => c.IdCategoria);




            modelBuilder.Entity<Categoria>().HasData(Trabajo, Diversion);
            modelBuilder.Entity<Url>().HasData(url, url1, url2);
            modelBuilder.Entity<User>().HasData(Usuario1, Usuario2, Usuario3);

            base.OnModelCreating(modelBuilder);

        }
    }
}