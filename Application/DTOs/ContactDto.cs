using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ContactDto
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
