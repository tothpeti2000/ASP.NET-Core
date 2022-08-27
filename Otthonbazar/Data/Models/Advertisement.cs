using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Data.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A cím megadása kötelező")]
        [Display(Name = "Cím")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Az építés évének megadása kötelező")]
        [Display(Name = "Építés éve")]
        public int BuildDate { get; set; }

        [Display(Name = "Leírás")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A fél szobák számának megadása kötelező")]
        [Display(Name = "Fél szobák")]
        public int HalfRoom { get; set; }

        [Display(Name = "Fénykép")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Az eladási ár megadása kötelező")]
        [Display(Name = "Eladási ár")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A szobák számának megadása kötelező")]
        [Display(Name = "Szobák")]
        public int Room { get; set; }

        [Required(ErrorMessage = "Az alapterület megadása kötelező")]
        [Display(Name = "Alapterület")]
        public int Size { get; set; }

        public int CityId { get; set; }
        [Display(Name = "Város")]
        public City City { get; set; }

        [Required(ErrorMessage = "A típus megadása kötelező")]
        [Display(Name = "Típus")]
        public AdvertisementType AdvertisementType { get; set; }
    }
}
