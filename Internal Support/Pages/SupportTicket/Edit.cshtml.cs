using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internal_Support.Data;
using Internal_Support.Models;
using System.Net;
using System.ComponentModel;
using Xceed.Wpf.Toolkit;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Internal_Support.Pages.SupportTicket
{
    public class EditModel : PageModel
    {
        private readonly Internal_Support.Data.Internal_SupportContext _context;

        public EditModel(Internal_Support.Data.Internal_SupportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupportTickets SupportTickets { get; set; }
        public List<TicketAssigned> TicketAssigned { get; set; }
        public List<TicketStatus> TicketStatus { get; set; }

        //public string Attachment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupportTickets = await _context.SupportTickets.FirstOrDefaultAsync(m => m.Id == id);

            //Attachment = SupportTickets.pathFile;

            TicketAssigned = await _context.TicketAssigned.ToListAsync();
            var ticket1 = new SelectList(TicketAssigned, "AssignedTo", "AssignedTo");
            ViewData["AssignedList"] = ticket1;

            TicketStatus = await _context.TicketStatus.ToListAsync();
            var ticket2 = new SelectList(TicketStatus, "Status", "Status");
            ViewData["StatusList"] = ticket2;

            if (SupportTickets == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SupportTickets.UpdatedDate = DateTime.Now;

            
            SupportTickets.Assigned = Request.Form["AssignedData"].ToString();
            SupportTickets.Status = Request.Form["StatusData"].ToString();
           
           
            _context.Attach(SupportTickets).State = EntityState.Modified;
            
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketsExists(SupportTickets.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           

            return RedirectToPage("./Index");

        }

        private bool SupportTicketsExists(int id)
        {
            return _context.SupportTickets.Any(e => e.Id == id);
        }
        
    }
}
