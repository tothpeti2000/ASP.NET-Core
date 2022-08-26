using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Data.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int BuildDate { get; set; }

        public string Description { get; set; }

        [Required]
        public int HalfRoom { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Room { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        public AdvertisementType AdvertisementType { get; set; }
    }
}
