using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class DeleteGroupsLINQ : IDeleteGroup
    {
        public void Execute(OurContext context, int id)
        {
            var groupsWithMethodSyntax = context.groups.Where(g => g.Id == id).FirstOrDefault();
            var groupsWithQuerySyntax = (from groups in context.groups
                                        where groups.Id == id
                                        select groups).FirstOrDefault();

            context.groups.Remove(groupsWithQuerySyntax);
            context.SaveChanges();
        }
    }
}
