using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        static DbContext()
        {
            Admins = new List<Admin>();
            Drugs = new List<Drug>();
        }
    }
}
