using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_and_orm.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public int GroupId { get; set; }
    }
}
