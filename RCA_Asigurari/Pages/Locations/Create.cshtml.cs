using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;
using RCA_Asigurari.Services;

namespace RCA_Asigurari.Pages.Locations
{
    public class CreateModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public CreateModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {


            if (!_context.Location_1.Any())
            {
                string jsonFilePath = "C:\\Users\\Paula\\Downloads\\localitati.json";
                JsonLocationService jsonLocationService = new JsonLocationService();
                List<JsonLocation> jsonLocations = await jsonLocationService.ReadJsonFileAsync(jsonFilePath);

                foreach (JsonLocation jsonLocation in jsonLocations)
                {
                    Location location = new Location
                    {
                        Judet = jsonLocation.Judet,
                        Localitate = jsonLocation.Nume
                    };

                    _context.Location_1.Add(location);
                }

                await _context.SaveChangesAsync();
            }


            return Page();
        }

        [BindProperty]
        public Location Location { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Location == null || Location == null)
            {
                return Page();
            }

            _context.Location_1.Add(Location);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}