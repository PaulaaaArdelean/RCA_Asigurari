using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RCA_Asigurari.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ContactUsModel(RCA_Asigurari.Data.RCA_AsigurariContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {
            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                 .Where(c => c.Email == userName)
                 .Select(x => new
                 {
                     x.ID,
                     DetaliiClient = x.NumeProprietar
                 });
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");

        }
    }
}
