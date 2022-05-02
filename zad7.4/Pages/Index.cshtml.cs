using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zad7._4.Data;
using zad7._4.Models;
using zad7._4.Pages;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace zad7._4.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public bool extra, gender;
        public bool hide = true;

        [BindProperty]
        public YearUser user { get; set; }
        public List<YearUser> list = new List<YearUser>();
        public List<YearUser> listDB = new List<YearUser>();

        
        public void OnGet()
        {
            listDB = _context.User.OrderBy(p => p.name).ToList();
        }

        public IActionResult OnPost()
        {
            listDB = _context.User.OrderBy(p => p.name).ToList();

            if (ModelState.IsValid)
            {
                ViewData["extraY"] = user.year;
                ViewData["user"] = user.name;
                extra = user.ExtraYear();
                gender = user.Gender();
                hide = false;

                if (HttpContext.Session.GetString("YearList") == null)
                {
                    list.Add(user);
                    HttpContext.Session.SetString("YearList", JsonConvert.SerializeObject(list));
                }

                else
                {
                    var sessionList = HttpContext.Session.GetString("YearList");
                    list = JsonConvert.DeserializeObject<List<YearUser>>(sessionList);
                    list.Add(user);
                    HttpContext.Session.SetString("YearList", JsonConvert.SerializeObject(list));
                }

                _context.User.Add(user);
                _context.SaveChanges();

                //return RedirectToPage("./Index");
            }
            //return RedirectToPage("./Index"); // brak komunikatów

            return Page();
        }




    }
}