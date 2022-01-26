using BusinessLayer.Requests;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPutUser
    {
        public void PutUser(OurContext context, PutUserRequest request);
    }
}
