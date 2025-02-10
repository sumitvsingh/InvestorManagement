using InvestorManagement.Api.CustomLogics;
using Microsoft.AspNetCore.Mvc;

namespace InvestorManagement.Api.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly JwtTokenService _jwtTokenService;

		public AuthController(JwtTokenService jwtTokenService)
		{
			_jwtTokenService = jwtTokenService;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginModel model)
		{
			// Dummy user authentication (replace with database validation)
			if (model.Username == "admin" && model.Password == "password")
			{
				var token = _jwtTokenService.GenerateToken(model.Username);
				return Ok(new { token });
			}

			return Unauthorized("Invalid credentials");
		}
	}

	// Login model
	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
