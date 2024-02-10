using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AdminLoginDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
