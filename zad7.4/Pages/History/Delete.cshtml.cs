#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zad7._4.Data;
using zad7._4.Models;

namespace zad7._4.Pages.History
{
    public class DeleteModel : PageModel
    {
        private readonly zad7._4.Data.ApplicationDbContext _context;

        public DeleteModel(zad7._4.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HistoryUser HistoryUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HistoryUser = await _context.History
                .Include(h => h.YearUser).FirstOrDefaultAsync(m => m.Id == id);

            if (HistoryUser == null)
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

            HistoryUser = await _context.History.FindAsync(id);

            if (HistoryUser != null)
            {
                _context.History.Remove(HistoryUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
