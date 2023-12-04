using Application.Services.AdminService;
using Application.UseCases.Admin;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<int>> Register(CreateAdminDto request)
        {
            var response = await _adminService.Register(new Admin { Email = request.Email }, request.Password);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(AuthenticateAdminDto request)
        {
            var response = await _adminService.Login(request.Email, request.Password);
            return Ok(response);
        }
    }
}
