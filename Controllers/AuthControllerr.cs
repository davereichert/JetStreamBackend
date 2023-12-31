﻿using JetStreamBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SkiServiceContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(SkiServiceContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        var user = await _context.Mitarbeiter
            .FirstOrDefaultAsync(u => u.Benutzername == login.Username);
        if (user == null || user.IstGesperrt)
        {
            return Unauthorized("Benutzer nicht gefunden doer gespert wende dich an einen mitarbeiter");
        }

        if(login.Password != user.Passwort)
        {
            user.LoginVersuche++;
            if(user.LoginVersuche >= 3) {
                user.IstGesperrt = true;
                
            
            }
            await _context.SaveChangesAsync();
            return Unauthorized("Falsches Passwort");
        }

        user.LoginVersuche = 0;
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(user.Benutzername);

        return Ok(new { token });
    }

    private string GenerateJwtToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}


