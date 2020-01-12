using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrudApi.Core;
using CrudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepostory _repostory;
        private readonly IMapper _mapper;
        public UserController(IUserRepostory repostory,IMapper mapper)
        {
            _repostory = repostory;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> AddUserAsync(User user)
        {
            try
            {
                await _repostory.AddUserAsync(user);
                return Created("", "User is Created");
            }
            catch
            {
                return BadRequest("User is not Created");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserAsync(int id)
        {
            try
            {
                var user = await _repostory.GetUser(id);
                return Ok(user);
            }
            catch
            {
                return BadRequest("There Haven't That User");
            }
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var users = await _repostory.GetUsers();

                return users;
            }
            catch
            {
                // return BadRequest("There Haven't That Users");
                return null;
            }
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _repostory.DeleteUser(id);
        }
        [HttpPut("{id}")]
        public void UpdateProduct(int id, User user)
        {
            _repostory.UpdateUser(id, user);
        }
    }
}