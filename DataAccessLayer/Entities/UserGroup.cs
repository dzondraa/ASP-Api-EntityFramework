using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public User user { get; set; }
        public Group group { get; set; }
    }
}
