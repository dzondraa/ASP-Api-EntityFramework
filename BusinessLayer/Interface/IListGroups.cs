using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IListGroups

    {
        public Task<List<object>> listAllGroups(OurContext context);
    }
}
