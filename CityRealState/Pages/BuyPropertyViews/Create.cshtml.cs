using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityRealEstate.Data;
using CityRealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace CityRealEstate.Pages.BuyPropertyViews
{
    public class CreateModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public CreateModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> properties { get; set; }
        public async Task OnGet()
        {
            properties = await _context.Property.ToListAsync();
        }


        [BindProperty]
        public BuyProperty BuyProperty { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BuyProperty.Add(BuyProperty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
