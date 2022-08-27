using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Data.Models
{
    public class SearchModel
    {
        [Display(Name = "Város")]
        public int? CityId { get; set; }
        public string CityName { get; set; }

        [Display(Name = "Ár")]
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }

        [Display(Name = "Szobák")]
        public int? RoomMin { get; set; }
        public int? RoomMax { get; set; }

        [Display(Name = "Alapterület")]
        public int? SizeMin { get; set; }
        public int? SizeMax { get; set; }
    }
}
