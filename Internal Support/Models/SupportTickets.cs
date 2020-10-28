using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internal_Support.Models
{
    public class SupportTickets
    {
        [Key]
        public int Id { get; set; }

        public string YourMail { get; set; }

        public string Subject { get; set; }
            
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd}")]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd}")]
        public DateTime ? UpdatedDate { get; set; }
        
        public string Status { get; set; }

        public string Assigned { get; set; }


         public string pathFile { get; set; }

    }
}
