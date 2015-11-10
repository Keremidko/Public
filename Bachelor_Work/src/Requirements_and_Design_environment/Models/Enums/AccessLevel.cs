using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Requirements_and_Design_environment.Models.Enums
{
    public enum Accessibility
    {
        Owner = 1,
        Read_Edit = 2,
        Read_Edit_Create = 3,
        Read_Edit_Create_Delete = 4
    }
}