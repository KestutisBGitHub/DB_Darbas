using DB_Darbas.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB_Darbas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IJwtService _jwtService;

        public UserController(IAccountsService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        [HttpGet("All")]
        public List<Account> GetAll()
        {
            return _accountsService.GetAll();
        }
        [HttpGet("Get By ID")]
        public Account GetAdmin(int id)
        {
            return _accountsService.GetById(id);
        }
        [HttpGet("Get by UserName")]
        public Account GetByUserName(string userName)
        {
            //using var dbContext = new RegistryDbContext();
            //var usersFromDb = dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            ////var personID = usersFromDb.PersonID;
            ////var personFromDb = dbContext.Persons.FirstOrDefault(y => y.Id == personID);
            ////var locationId = personFromDb.LocationID;
            ////var locationFromDb = dbContext.Locations.FirstOrDefault(z => z.Id == locationId);
            ////var userData = usersFromDb + personFromDb + locationFromDb;
            //return usersFromDb;
            return _accountsService.GetByUserName(userName);
        }
        //[HttpPatch("User")]
        //public void Patch(AuthRequestDto authRequest)
        //{

        //    _accountsService.UpdateByUserName(authRequest., /*userUpdatedinfo.Password,*/ userUpdatedinfo.Person.Name, userUpdatedinfo.Person.Surname,
        //        userUpdatedinfo.Person.PersonalCode, userUpdatedinfo.Person.PhoneNumber, userUpdatedinfo.Person.Email, userUpdatedinfo.Person.Location.City, userUpdatedinfo.Person.Location.Street, userUpdatedinfo.Person.Location.HouseNr, userUpdatedinfo.Person.Location.AppartmentNr);


        //}
        [HttpDelete]
        public void Delete(int id)
        {
            _accountsService.DeleteByID(id);
        }
    }
}
