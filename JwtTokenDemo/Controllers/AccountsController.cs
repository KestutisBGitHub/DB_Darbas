using DB_Darbas.BL;
using DB_Darbas.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB_Darbas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IJwtService _jwtService;

        public AccountsController(IAccountsService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        [HttpPost("SignUp")]
        public ActionResult Signup([FromQuery]AuthRequestDto request, [FromQuery] PersonDTO peronalData, [FromQuery] LocationDto locationData
            )
        {
            _accountsService.SignupNewAccount(request.UserName, request.Password
                , peronalData.Name, peronalData.Surname, peronalData.PersonalCode, peronalData.PhoneNumber, peronalData.Email,
                locationData.City, locationData.Street, locationData.HouseNr, locationData.AppartmentNr
                );
            return Ok();
        }

        [HttpPost("Login")]
        public ActionResult Login(AuthRequestDto request)
        {
            var (loginSuccess, account) = _accountsService.Login(request.UserName, request.Password);

            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                var jwt = _jwtService.GetJwtToken(account.Username, account.Id);
                return Ok($"{jwt}");
            }
        }

       
    }
}
