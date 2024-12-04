using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hair.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        [Required]
        public string? MusteriAdi { get; set; }

        [Required]
        [EmailAddress]
        public string? MusteriEmail { get; set; }

        [Required]
        public DateTime RandevuTarihi { get; set; }

        [Required]
        [ForeignKey("Islem")]
        public int IslemId { get; set; }
        public Islem? Islem { get; set; }

        [Required]
        [ForeignKey("Personel")]
        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }
    }
}
