using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CityRealEstate.Data;
using CityRealEstate.Models;

namespace CityRealEstate.Pages.BuyPropertyViews
{
    public class DeleteModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public DeleteModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BuyProperty BuyProperty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BuyProperty = await _context.BuyProperty.FirstOrDefaultAsync(m => m.id == id);

            if (BuyProperty == null)
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

            BuyProperty = await _context.BuyProperty.FindAsync(id);

            if (BuyProperty != null)
            {
                _context.BuyProperty.Remove(BuyProperty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
