using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data;
using Otthonbazar.Data.Models;

namespace Otthonbazar.Pages.Advertisements
{
    public class CreateModel : PageModel
    {
        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public CreateModel(Otthonbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return Page();
        }

        public ActionResult OnGetZip(int zip)
        {
            var city = _context.Cities
                .FirstOrDefault(c => c.Zip == zip.ToString());

            return new JsonResult(city);
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [Authorize]
        public async Task<IActionResult> OnPostAsync([FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/identity/account/login?returnUrl={Request.Path}");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Upload != null && Upload.Length > 0)
            {
                var webRoot = hostingEnvironment.WebRootPath;
                Advertisement.ImageUrl = $"image-{DateTime.UtcNow:yyyyMMdd-HHmmss}.jpg";
                
                var filePath = Path.Combine(webRoot, "images", Advertisement.ImageUrl);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Upload.CopyToAsync(stream);
                }
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Zip == Advertisement.City.Zip);

            Advertisement.City = city;

            _context.Advertisements.Add(Advertisement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}