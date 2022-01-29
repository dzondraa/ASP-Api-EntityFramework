using BusinessLayer.Requests;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPutGroup
    {
        public void PutGroup(OurContext context, PutGroupRequest request);
    }
}
