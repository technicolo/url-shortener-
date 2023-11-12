using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UrlShorter.Entities;

namespace UrlShortener.entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UrlShort { get; set; }

        public string? UrlLong { get; set; }

        public int contador { get; set; } = 1;

        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        [ForeignKey("IdUser")]

        public int IdUser { get; set; }

        public User? User { get; set; }


    }

}