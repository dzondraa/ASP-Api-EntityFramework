using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class GetGroupsById : IGetGroupsById
    {
        public IQueryable getGroupsById(OurContext context, int id)
        {
            var existingGroupQuery = from groups in context.groups
                                     where groups.Id == id
                                     select groups;

            var existingGroups = existingGroupQuery;
            return existingGroups;
        }
    }
}
