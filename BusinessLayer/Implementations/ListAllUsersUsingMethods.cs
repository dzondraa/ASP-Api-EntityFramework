using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class ListAllUsersUsingMethods : IListUsers
    {
        // Primer polimorfizma -> listAllUsers metoda ima isto ime 
        // ali se ponasa drugacije u zavisnosti od klase u kojoj se nalazi
        public IQueryable<object> listAllUsers(OurContext context)
        {
            // METHOD SINTAKSA
            var usersQuery = context.users.Join(context.userGroup,
                u => u.Id,
                ug => ug.user.Id,
                (u, ug) => new
                {
                    Name = u.Username,
                    Group = context.groups.Where(g => g.Id == ug.Id).ToList()
                });

            return usersQuery;
        }
    }
}
