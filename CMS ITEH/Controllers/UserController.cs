using CMS_ITEH.Models;
using CMS_ITEH.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS_ITEH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return CmsContext.Instance.Users.Include(p => p.Role).ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return CmsContext.Instance.Users.Find(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return CmsContext.Instance.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password); ;
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("add-user")]
        public void Add([FromBody] User user)
        {
            CmsContext.Instance.Users.Add(user);
            CmsContext.Instance.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPatch]
        [Route ("edit-user")]
        public void Update([FromBody] User user)
        {
            User usernew = CmsContext.Instance.Users.Find(user.UserId);
            usernew.UserName=user.UserName;
            usernew.Password = user.Password;
            usernew.RoleId = user.RoleId;
            usernew.LastName = user.LastName;
            usernew.FirstName = user.FirstName;
            CmsContext.Instance.Update(usernew);
            CmsContext.Instance.SaveChanges();

        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route ("delete-user")]
        
        public void Delete([FromBody]User user)
        {
            CmsContext.Instance.Remove(user);
            CmsContext.Instance.SaveChanges();
        }
    }
}
