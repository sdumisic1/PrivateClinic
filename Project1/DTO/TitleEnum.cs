using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public enum TitleEnum : byte
    {
        [Description("DOC")]
        Doctor = 1,

        [Description("NUR")]
        Nurse = 2,

        [Description("TEH")]
        Technician = 3,

        [Description("SPEC")]
        Specialist = 4,

        [Description("INT")]
        Intern = 5
    }
}
