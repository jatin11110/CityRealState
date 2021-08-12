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
    public class DeleteModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public DeleteModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReachUs = await _context.ReachUs.FindAsync(id);

            if (ReachUs != null)
            {
                _context.ReachUs.Remove(ReachUs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
