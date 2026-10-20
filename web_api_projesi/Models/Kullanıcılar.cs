using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_projesi.Models
{
    public class Kullanıcılar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullanıcıId { get; set; }
        public string KullanıcıAdı { get; set; }
        public string KullanıcıSoyadı { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Telefon { get; set; }  
        public string Adres { get; set; }
    }
}
