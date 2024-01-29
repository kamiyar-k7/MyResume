using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide
{
    public class ShowAllDto
    {
        #region Information
        public int Id { get; set; }
        public string UserName { get; set; }
        public string TitleDescription { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int MobilePhone { get; set; }
        public string Location { get; set; }
        public string PicName { get; set; }
        #endregion

        #region Service
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        #endregion
        #region Skill
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillValue { get; set; }
        #endregion

        #region Contacts
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Message { get; set; }
        #endregion

    }
}
