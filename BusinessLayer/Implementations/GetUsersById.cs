using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class GetUsersById : IGetUsersById
    {
        public IQueryable getUserById(OurContext context, int id)
        {
            var existingUserQuery = from user in context.users
                                    where user.Id == id
                                    select user;

            var existingUser = existingUserQuery;
            return existingUser;

            
        }
    }
}
