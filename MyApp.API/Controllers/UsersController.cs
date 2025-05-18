using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Logic;
using MyApp.DataAccess;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string login, string password, string name, int gender, DateOnly? birthday, bool isAdmin, string createdBy, string modifiedBy)
        {
            await userService.CreateAsync(login, password, name, gender, birthday, isAdmin, createdBy, modifiedBy);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ReadWhereRevokedOnIsNull()
        {
            var result = await userService.ReadWhereRevokedOnIsNull();
            return Ok(result);
        }

        [HttpGet("login/{login}")]
        public async Task<IActionResult> ReadyByLogin(string login)
        {
            var result = await userService.ReadByLogin(login);
            return Ok(result);
        }

        [HttpGet("login/{login}/password/{password}")]
        public async Task<IActionResult> ReadyByLoginAndPassword(string login, string password)
        {
            var result = await userService.ReadyByLoginAndPassword(login, password);
            return Ok(result);
        }

        [HttpGet("age/{age}")]
        public async Task<IActionResult> ReadWhereAgeMoreThan(int age)
        {
            var result = await userService.ReadWhereAgeMoreThan(age);
            return Ok(result);
        }

    }
} 
