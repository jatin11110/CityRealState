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
    public class IndexModel : PageModel
    {
        private readonly CityRealEstate.Data.CityRealEstateContext _context;

        public IndexModel(CityRealEstate.Data.CityRealEstateContext context)
        {
            _context = context;
        }

        public IList<ReachUs> ReachUs { get;set; }

        public async Task OnGetAsync()
        {
            ReachUs = await _context.ReachUs.ToListAsync();
        }
    }
}
