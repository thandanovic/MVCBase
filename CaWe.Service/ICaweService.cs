using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBase.Entities;

namespace MVCBase.Service 
{
    interface ICaweService
    {
        List<Role> GetAllRoles();
    }
}
