using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AdminSide
{
    public class AdminSideUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TitleDescription { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public long MobilePhone { get; set; }
        public string Location { get; set; }
        public string? PicName { get; set; }
        public IFormFile? pictureFile { get; set; }
    }
}
