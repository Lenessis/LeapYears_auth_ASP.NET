using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zad7._4.Models;
using zad7._4.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace zad7._4.Pages
{
    public class YearBaseModel : PageModel
    {
        public List<YearUser> listDB = new List<YearUser>();
        [BindProperty(SupportsGet = true)]
        public string user { get; set; }

        private readonly ILogger<YearBaseModel> _logger;
        private readonly ApplicationDbContext _context; // -- context bazy danych 

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

       // object userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        public YearBaseModel(ILogger<YearBaseModel> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        //dodac ostatnio szukane

        /*
         * Wyszukiwanie
         * Tutorial: https://www.youtube.com/watch?v=gb6TMtoGQEM
         */

        public void OnGet()
        {
            object userId = null;
            if (_signInManager.IsSignedIn(User))
            {
                userId = _userManager.GetUserId(User);
            }
            

            if (string.IsNullOrEmpty(user))
                listDB = _context.User.OrderBy(p => p.name).ToList();
            else
            {
                listDB = _context.User.Where(p => p.name.Contains(user) || p.lastname.Contains(user)).OrderBy(p => p.name).ToList();

                foreach (var item in listDB)
                {
                    if(_signInManager.IsSignedIn(User) && userId != null)
                    {
                        _context.History.Add(item.AddView(user,userId));
                    }
                    else                   
                        _context.History.Add(item.AddView(user));
                    _context.SaveChanges();
                }

            }

        }
    }
}
