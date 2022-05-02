using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using zad7._4.Models;

namespace zad7._4.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<YearUser> yearsList = new List<YearUser>();

        public void OnGet()
        {
            var YearData = HttpContext.Session.GetString("YearList");
            if (YearData != null)
                yearsList = JsonConvert.DeserializeObject<List<YearUser>>(YearData);
        }
    }
}
