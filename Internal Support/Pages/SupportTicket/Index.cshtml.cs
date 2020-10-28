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
    public class IndexModel : PageModel
    {
        private readonly Internal_Support.Data.Internal_SupportContext _context;

        public IndexModel(Internal_Support.Data.Internal_SupportContext context)
        {
            _context = context;
        }
        
        
        public PaginatedList<SupportTickets> SupportTickets { get; set; }
        

        public async Task OnGetAsync(int ? PageIndex)
        {

            IQueryable<SupportTickets> SupportTicketsIQ = from s in _context.SupportTickets
                                                          select s;

            int pageSize = 10;
            SupportTickets = await PaginatedList<SupportTickets>.CreateAsync(
                SupportTicketsIQ, PageIndex ?? 1, pageSize);

            
           
        }


    }
}
