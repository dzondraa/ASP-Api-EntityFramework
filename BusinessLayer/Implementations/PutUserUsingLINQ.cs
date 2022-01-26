using BusinessLayer.Interface;
using BusinessLayer.Requests;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class PutUserUsingLINQ : IPutUser
    {
        public void PutUser(OurContext context, PutUserRequest request)
        {
            // PROVERAVAMO DA LI POSTOJI USER
            var existingUserQuery = from user in context.users
                               where user.Id == request.Id
                               select user;

            var existingUser = existingUserQuery.FirstOrDefault();


            if(existingUser != null)
            {
                existingUser.Username = request.Username;
            }
            else
            {
                // instanciramo objekat iz Data sloja
                User userForInsert = new User();
                userForInsert.Username = request.Username;
                context.users.Add(userForInsert);
            }
            context.SaveChanges();
            
        }
    }
}
