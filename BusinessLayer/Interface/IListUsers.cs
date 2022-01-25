using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IListUsers
    {
        public IQueryable<object> listAllUsers(OurContext context);
    }
}
