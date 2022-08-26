using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required, StringLength(4, MinimumLength = 4)]
        public string Zip { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
