using ApiAppDemo.Application;
using ApiAppDemo.Application.Handlers.Authors.AddAuthor;
using ApiAppDemo.Application.Handlers.Authors.EditAuthor;
using ApiAppDemo.Application.Handlers.Authors.GetAuthor;
using ApiAppDemo.Application.Handlers.Authors.GetAuthors;
using ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAppDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppUserOptions _appUser;
    private readonly IConfiguration _config;

    public AuthController(IOptions<AppUserOptions> appUserOptions, IConfiguration config)
    {
        _appUser = appUserOptions.Value;
        _config = config;
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var user = User.Identity?.Name;
        return Ok(new { email = user });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Username != _appUser.Username || request.Password != _appUser.Password)
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(request.Username);
        return Ok(new { token, ok = true });
    }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = _config.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: [new Claim(ClaimTypes.Name, username)],
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiresInMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public record LoginRequest(string Username, string Password);
