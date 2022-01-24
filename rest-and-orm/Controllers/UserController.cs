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
            var users = context.users.ToList();
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

            User userForInsert = new User();
            userForInsert.Username = userRequest.Username;

            // Dodajemo u postojecu grupu

            var existingGroup = context.groups.Where(u => u.Id == userRequest.GroupId).FirstOrDefault();

            if (existingGroup == null)
                return BadRequest("Ne postoji grupa sa ID: " + userRequest.GroupId);

            // Pravimo novu grupu

            //var newGroup = new Group();
            //newGroup.Name = "Groupa 1";

            userForInsert.group = existingGroup;
            context.users.Add(userForInsert);

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
