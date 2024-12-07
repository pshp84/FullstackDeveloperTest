using FlightManagementSystem.DTOs;
using FlightManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var notifications = await _userRepo.GetUsersAsync();
            return Ok(new CommonResponse { Status = Status.Success, Data = notifications });
        } 
    }
}
