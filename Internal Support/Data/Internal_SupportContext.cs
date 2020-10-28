using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Internal_Support.Models;

namespace Internal_Support.Data
{
    public class Internal_SupportContext : DbContext
    {
        public Internal_SupportContext(DbContextOptions<Internal_SupportContext> options)
            : base(options)
        {
        }

        public DbSet<Internal_Support.Models.SupportTickets> SupportTickets { get; set; }

        public DbSet<Internal_Support.Models.TicketAssigned> TicketAssigned { get; set; }

        public DbSet<Internal_Support.Models.TicketStatus> TicketStatus { get; set; }
       
    }
}