﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hair.Models
{
    public class Personel
    {

        [Key]
        public int PersonelId { get; set; }

        [Required]
        public string? Ad { get; set; }
        [Required]
        public string? Soyad { get; set; }
        [Required]
        public string? Sehir { get; set; }


        [Required]
        [ForeignKey("Islem")]
        public int IslemId { get; set; }

        public Islem? Islem { get; set; }

    }
}
