using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CityRealEstate.Data;
using CityRealEstate.Models;

namespace CityRealEstate.Pages.ReachUsViews
{
    public class DetailsModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public DetailsModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        public ReachUs ReachUs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReachUs = await _context.ReachUs.FirstOrDefaultAsync(m => m.id == id);

            if (ReachUs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
