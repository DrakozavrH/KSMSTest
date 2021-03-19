using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills
{
    public static class MyExtensions
    {
        public static bool IsEmpty(this String str)
        {
            return str == "" ? true : false;
        }
    }
}
