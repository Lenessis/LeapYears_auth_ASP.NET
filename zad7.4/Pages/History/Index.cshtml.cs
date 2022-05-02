#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zad7._4.Data;
using zad7._4.Models;


namespace zad7._4.Pages.History
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly zad7._4.Data.ApplicationDbContext _context;

        public IndexModel(zad7._4.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HistoryUser> HistoryUser { get;set; }

        public async Task OnGetAsync()
        {
            HistoryUser = await _context.History
                .Include(h => h.YearUser).ToListAsync();
        }
    }
}
