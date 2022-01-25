using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rest_and_orm.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rest_and_orm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromServices] OurContext context)
        {
            var users = context.users.Join(context.userGroup,
                u => u.Id,
                ug => ug.user.Id,
                (u, ug) => new
                {
                    Name = u.Username,
                    Group = context.groups.Where(g => g.Id == ug.Id).ToList()
                }).ToList();
              
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromServices] OurContext context, [FromBody] CreateUserRequest userRequest)
        {
            // novi user
            User userForInsert = new User();
            userForInsert.Username = userRequest.Username;

            // nova grupa
            var newGroup = new Group();
            newGroup.Name = "Groupa X";

            // insert
            context.groups.Add(newGroup);
            context.users.Add(userForInsert);

            // make relation
            context.userGroup.Add(new UserGroup { user = userForInsert, group = newGroup });


            //userForInsert.groups = existingGroup;
            context.SaveChanges();
            return Ok("Uspesan insert");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateUserRequest value)
        {
            
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
