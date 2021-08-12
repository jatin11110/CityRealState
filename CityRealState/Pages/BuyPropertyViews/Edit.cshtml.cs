using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityRealEstate.Data;
using CityRealEstate.Models;

namespace CityRealEstate.Pages.BuyPropertyViews
{
    public class EditModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public EditModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BuyProperty BuyProperty { get; set; }
        public IEnumerable<Property> properties { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BuyProperty = await _context.BuyProperty.FirstOrDefaultAsync(m => m.id == id);
            properties = await _context.Property.ToListAsync();
            if (BuyProperty == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BuyProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyPropertyExists(BuyProperty.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BuyPropertyExists(int id)
        {
            return _context.BuyProperty.Any(e => e.id == id);
        }
    }
}
