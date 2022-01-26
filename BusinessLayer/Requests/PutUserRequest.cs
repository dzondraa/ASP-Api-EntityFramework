using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Requests
{
    public class PutUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
