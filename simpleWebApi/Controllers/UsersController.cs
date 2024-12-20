﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleWebApi.Data.Services;
using simpleWebApi.DTO;

namespace simpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _service;
        public UsersController(IUserServices services)
        {
            _service = services;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _service.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _service.GetById(id);
            if (user == null) { 
            
                return NotFound();
            }
            return Ok(user);    
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutUser (int id, UserDto userDto) 
        { 

            var user = await _service.Update(id, userDto);
            if (user == null) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto) 
        {
            var user = await _service.Add(userDto);
            return CreatedAtAction("GetUser", new {id=user.Id }, userDto);
        
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            await _service.Delete(id);
            return NoContent();

        }
    }
}
