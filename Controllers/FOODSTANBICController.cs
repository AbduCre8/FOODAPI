namespace WebAPIPractise.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using WebAPIPractise.Context;
    using WebAPIPractise.model;

    [Route("api/user")]
    [ApiController]
    public class FOODSTANBICController : ControllerBase
    {
        private FOODSTANBICContext _foodstanbiccontext;
        public FOODSTANBICController (FOODSTANBICContext foodstanbicContext)
        {
            _foodstanbiccontext = foodstanbicContext;
        }

        // GET: api/<FOODSTANBICController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _foodstanbiccontext.Users;
        }

        // GET api/<FOODSTANBICController>/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return _foodstanbiccontext.Users.FirstOrDefault(s => s.UserId == id);
        }

        // POST api/<FOODSTANBICController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _foodstanbiccontext.Users.Add(value);
            _foodstanbiccontext.SaveChanges();
        }
    }
}