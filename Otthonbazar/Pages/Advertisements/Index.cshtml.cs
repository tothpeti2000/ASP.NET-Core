using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data;
using Otthonbazar.Data.Models;

namespace Otthonbazar.Pages.Advertisements
{
    public class IndexModel : PageModel
    {
        public IList<Advertisement> Advertisement { get; set; }

        [BindProperty(SupportsGet = true)]
        public SearchModel Search { get; set; }

        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public IndexModel(Otthonbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            IQueryable<Advertisement> advertisements = _context.Advertisements.Include(a => a.City);

            advertisements = advertisements
                .Where(a => (Search.CityName == null || InputMatch(Search.CityName, a.City.Name)) &&
                            (Search.PriceMin == null || a.Price >= Search.PriceMin.Value) &&
                            (Search.PriceMax == null || a.Price <= Search.PriceMax.Value) &&
                            (Search.SizeMin == null || a.Size >= Search.SizeMin.Value) &&
                            (Search.SizeMax == null || a.Size <= Search.SizeMax.Value) &&
                            (Search.RoomMin == null || GetTotalRooms(a) >= Search.RoomMin.Value) &&
                            (Search.RoomMax == null || GetTotalRooms(a) <= Search.RoomMax.Value));

            Advertisement = await advertisements.ToListAsync();
        }

        private bool InputMatch(string input, string compare)
        {
            return compare.ToUpper().Contains(input.ToUpper());
        }

        private int GetTotalRooms(Advertisement advertisement)
        {
            return advertisement.Room + advertisement.HalfRoom / 2;
        }
    }
}
