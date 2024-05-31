using Microsoft.AspNetCore.Mvc;
using NaLibApi.DTO;
using NaLibApi.Services;

namespace NaLibApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authService;

    public AuthenticationController(AuthenticationService authService) => _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(CredentialDto userLogin)
    {
        try
        {
            var result = await _authService.AunthenticateAsync(userLogin);
            return Ok(new { Token = result });
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                "An error occurred while processing your request. Please contact the administrator."
            );
        }
    }
}
