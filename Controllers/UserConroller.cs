using IvanGovnov.DTOs;
using RESTtraining.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IvanGovnov.Data;



[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetAll()
    {
        var result = _context.Users
            .Select(u => new UserDto
            {
                Name = u.Name,
                Age = u.Age,
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> GetById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        var dto = new UserDto
        {
            Name = user.Name,
            Age = user.Age,
        };

        return Ok(dto);
    }

    [HttpPost]
    public ActionResult<UserDto> Create(UserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            Name = dto.Name,
            Age = dto.Age
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        user.Name = dto.Name;
        user.Age = dto.Age;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}
