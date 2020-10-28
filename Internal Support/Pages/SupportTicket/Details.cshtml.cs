using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Internal_Support.Data;
using Internal_Support.Models;

namespace Internal_Support.Pages.SupportTicket
{
    public class DetailsModel : PageModel
    {
        private readonly Internal_Support.Data.Internal_SupportContext _context;

        public DetailsModel(Internal_Support.Data.Internal_SupportContext context)
        {
            _context = context;
        }

        public SupportTickets SupportTickets { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTickets = await _context.SupportTickets.FirstOrDefaultAsync(m => m.Id == id);

            if (SupportTickets == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
