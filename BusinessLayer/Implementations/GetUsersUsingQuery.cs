using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class GetUsersUsingQuery : IListUsers
    {
        public IQueryable<object> listAllUsers(OurContext context)
        {
            var usersQuery = from user in context.users
                             join userGroup in context.userGroup
                             on user.Id equals userGroup.user.Id

                             join groups in context.groups
                             on userGroup.@group.Id equals groups.Id

                             select new
                             {
                                 Username = user.Username,
                                 Group = groups
                             };

            return usersQuery;
        }
    }
}
