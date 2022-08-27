using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Az irányítószám megadása kötelező"), StringLength(4, MinimumLength = 4, ErrorMessage = "Az irányítószám legalább 4 karakter")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "A város megadása kötelező")]
        public string Name { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
