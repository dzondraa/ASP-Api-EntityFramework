using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class DeleteUserLINQ : IDeleteUser
    {
        public void Execute(OurContext context, int id)
        {
            var userWithMethodSyntax = context.users.Where(u => u.Id == id).FirstOrDefault();
            var userWithQuerySyntax = from user in context.users
                                      where user.Id == id
                                      select user;

            context.users.Remove(userWithMethodSyntax);
            context.SaveChanges();

                        
            
        }
    }
}
