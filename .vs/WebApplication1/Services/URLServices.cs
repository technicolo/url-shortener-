using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UrlShortener.entities;
using UrlShorter.Data;
using UrlShorter.Entities;

namespace UrlShorter.Services
{
    public class URLServices
    {
        private readonly URLShortContext _context;
        public URLServices(URLShortContext context)
        {
            _context = context;
        }

        public List<Categoria> GetCategorias()
        {
            return _context.Categoria.ToList();
        }

        public string CrearShortUrl(string url)
        {
            // Genera una cadena aleatoria para la URL corta
            StringBuilder shortUrl = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                shortUrl.Append(CharSet[random.Next(CharSet.Length)]);
            }

            return shortUrl.ToString();
        }

        public string GuardarURL(string URLUser, string ShortURL, string? categoria, int IdUser)
        {
            

            Url URLToCreate = new Url();
            URLToCreate.UrlLong = URLUser;
            URLToCreate.UrlShort = ShortURL;
            URLToCreate.IdUser = IdUser;
            
            if (categoria != null) 
            { URLToCreate.IdCategoria = _context.Categoria.SingleOrDefault(u => u.Name == categoria).Id; }
            else URLToCreate.IdCategoria = 1;



            _context.Urls.Add(URLToCreate);
            Console.WriteLine(URLToCreate.ToString());
            _context.SaveChanges();

            return URLToCreate.ToString();
        }

        public int SumarContador(string URLUser)
        {
            Url URLToCreate = new Url();
            if (URLUser.Length > 6)
                URLToCreate = _context.Urls.SingleOrDefault(u => u.UrlLong == URLUser);
            else { URLToCreate = _context.Urls.SingleOrDefault(u => u.UrlShort == URLUser); }
            URLToCreate.contador++;
            _context.Urls.Update(URLToCreate);
            _context.SaveChanges();

            return URLToCreate.contador;

        }

        public List<string> GetUrlsPorUsuario(int IdUserClient)
        {
            List<string> URLSPorUsuario = _context.Urls.Where(x=> x.IdUser == IdUserClient).Select(x=> x.UrlLong).ToList();


            return URLSPorUsuario;
        }

        public string GetURLLongForShort(string URLCliente)
        {

            string URLLong = _context.Urls.SingleOrDefault(x => x.UrlShort == URLCliente).UrlLong;

            return URLLong ;
        }

    }
}
