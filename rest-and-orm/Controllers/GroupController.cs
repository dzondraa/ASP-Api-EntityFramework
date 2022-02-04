using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rest_and_orm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        // GET: api/<GroupController>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] OurContext context,
            [FromServices] IListGroups listGroupsQuery) => Ok(await listGroupsQuery.listAllGroups(context));

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IGetGroupsById query,
            [FromServices] OurContext context)
        {
            var groupsForReturn = query.getGroupsById(context, id);
            return Ok(groupsForReturn);
            
        }

        // POST api/<GroupController>
        [HttpPost]
        public IActionResult Post([FromServices] OurContext context, [FromBody] CreateGroupRequest groupRequest)
        {
            Group groupForInsert = new Group();
            groupForInsert.Name = groupRequest.Name;

            context.groups.Add(groupForInsert);
            context.SaveChanges();
            return Ok("Uspesan insert");

        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public void Put(int id,
            [FromBody] PutGroupRequest request,
            [FromServices] IPutGroup query,
            [FromServices] OurContext context)
        {
            request.Id = id;
            query.PutGroup(context, request);

        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id,
            [FromServices] IDeleteGroup query,
            [FromServices] OurContext context)
        {
            query.Execute(context, id);
        }
    }
}
