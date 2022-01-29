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
    public class PutGroupsUsingLinq : IPutGroup
    {
        public void PutGroup(OurContext context, PutGroupRequest request)
        {
            var existingGroupQuery = from groups in context.groups
                                     where groups.Id == request.Id
                                     select groups;

            var existingGroup = existingGroupQuery.FirstOrDefault();

            if(existingGroup != null)
            {
                existingGroup.Name = request.Name;
            }
            else
            {
                Group groupForInsert = new Group();
                groupForInsert.Name = request.Name;
                context.groups.Add(groupForInsert);
            }
            context.SaveChanges();
        }
    }
}
