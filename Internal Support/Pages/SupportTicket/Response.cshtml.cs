using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internal_Support.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Internal_Support.Pages.SupportTicket
{
    public class ResponseModel : PageModel
    {
        private readonly Internal_Support.Data.Internal_SupportContext _context;
        
        public ResponseModel(Internal_Support.Data.Internal_SupportContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupportTickets SupportTicket { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SupportTickets.Add(SupportTicket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
    }
}
