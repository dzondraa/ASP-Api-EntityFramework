using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class GetGroupsUsingQuery : IListGroups
    {
        public Task<List<object>> listAllGroups(OurContext context)
        {
            var groupsQuery = from groups in context.groups
                              select new
                              {
                                  Name = groups.Name,
                                  Id = groups.Id
                              };
            var task = new Task<List<object>>(() =>
            {
                return groupsQuery.ToList<object>();
            });
            task.Start();
            return task;
        }
    }
}
