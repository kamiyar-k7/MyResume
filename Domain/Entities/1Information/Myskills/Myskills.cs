using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities._1Information.Myskills
{
    public class Myskills
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillValue { get; set; }

    }
}
